using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExcel
{
    public class ParserException : ApplicationException
    {
        public int row;
        public int col;
        public ParserException(string str, int row, int col) : base (str)
        {
            this.row = row;
            this.col = col;
        }
        public override string ToString()
        {
            return Message;
        }
    }
    class Parser
    {
        enum Types { NONE, DELIMITER, VARIABLE, NUMBER };
        enum Errors { SYNTAX, UNBALPARENS, NOEXP, DIVBYZERO, RECURCELLS, REFWITHERROR, NOTEXISTCELL};
        string exp;
        int expIdx;
        string token;
        Types tokType;

        Cell currentCell;
        int currentRowCell;
        int currentColCell;

        double[] vars = new double[26];
        public Parser()
        {
            for (int i = 0; i < vars.Length; i++)
            {
                vars[i] = 0.0;
            }
        }
        public Cell Cell
        {
            get => default(Cell);
            set { }
        }
        public double Evaluate(string expStr, Cell _currentCell)
        {
            currentCell = _currentCell;
            int index = 65; //?
            currentColCell = _currentCell.ColumnLetter - index;
            currentRowCell = _currentCell.RowNumber - 1;
            currentCell.References.Clear();
            double result;
            exp = expStr;
            expIdx = 0;

            GetToken();
            if (token == "")
            {
                SyntaxErr(Errors.NOEXP); //?
                return 0.0;
            }
            EvalExp1(out result);//?
            if (token != "")
            {
                SyntaxErr(Errors.SYNTAX);
            }
            if(CheckRecurInCell(currentCell))
            {
                SyntaxErr(Errors.RECURCELLS);
            }
            return result;
        }
        bool CheckRecurInCell(Cell cell)
        {
            foreach(var i in cell.References)
            {
                if (i == currentCell)
                    return true;
                if (CheckRecurInCell(i) == true)
                    return true;
            }
            return false;
        }
        void EvalExp1(out double result)
        {
            string op;
            double partialResult;
            EvalExp2(out result);
            while((op = token) == "<" || op == ">" || op == "<=" || op == ">=" || op == "=" || op == "<>") 
            {
                GetToken();
                EvalExp2(out partialResult);
                switch(op)
                {
                    case "<":
                        result = result < partialResult ? 1 : 0;
                        break;
                    case ">":
                        result = result > partialResult ? 1 : 0;
                        break;
                    case "<=":
                        result = result <= partialResult ? 1 : 0;
                        break;
                    case ">=":
                        result = result >= partialResult ? 1 : 0;
                        break;
                    case "=":
                        result = result == partialResult ? 1 : 0;
                        break;
                    case "<>":
                        result = result != partialResult ? 1 : 0;
                        break;
                }
            }

        }
        void EvalExp2(out double result)
        {
            string op;
            double partialResult;
            EvalExp3(out result);
            while ((op = token) == "+" || op == "-")
            {
                GetToken();
                EvalExp3(out partialResult);
                switch (op)
                {
                    case "+":
                        result += partialResult;
                        break;
                    case "-":
                        result -= partialResult;
                        break;
                }
            }
        }
        void EvalExp3(out double result)
        {
            string op;
            double partialResult = 0.0;
            EvalExp4(out result);
            while ((op = token) == "*" || op == "/" || op == "m" || op == "d")
            {
                GetToken();
                EvalExp4(out partialResult);
                switch(op)
                {
                    case "*":
                        result *= partialResult;
                        break;
                    case "/":
                        if (partialResult == 0.0) SyntaxErr(Errors.DIVBYZERO);
                        result /= partialResult;
                        break;
                    case "m":
                        if (partialResult == 0.0) SyntaxErr(Errors.DIVBYZERO);
                        result = (int)result %(int)partialResult;
                        break;
                    case "d":
                        if (partialResult == 0.0) SyntaxErr(Errors.DIVBYZERO);
                        result = (int)result / (int)partialResult;
                        break;
                }
            }   
        }
        void EvalExp4(out double result)
        {
            double partialResult, ex;
            int t;
            EvalExp5(out result);
            if (token == "^")
            {
                GetToken();
                EvalExp4(out partialResult);
                ex = result;
                if (partialResult == 0.0)
                {
                    result = 1.0;
                    return;
                }
                for (t = (int)partialResult - 1; t > 0; t--)
                    result *= (double)ex;
            }
        }
        void EvalExp5(out double result)
        {
            if ((token == "("))
            {
                GetToken();
                EvalExp1(out result);
                if (token != ")")
                    SyntaxErr(Errors.UNBALPARENS);
                GetToken();
            }
            else Atom(out result);
        }
        void Atom(out double result)
        {
            switch (tokType)
            {
                case Types.NUMBER:
                    try
                    {
                        result = Double.Parse(token);
                    }
                    catch (FormatException)
                    {
                        result = 0.0;
                        SyntaxErr(Errors.SYNTAX);
                    }
                    GetToken();
                    return;
                case Types.VARIABLE:
                    result = FindVar(token);
                    GetToken();
                    return;
                default:
                    result = 0.0;
                    SyntaxErr(Errors.SYNTAX);
                    break;
            }
        }
        double FindVar(string vname)
        {
            if(!Char.IsLetter(vname[0]))
            {
                SyntaxErr(Errors.SYNTAX);
                return 0.0;
            }
            return vars[Char.ToUpper(vname[0]) - 'A'];
        }
        void PutBack()
        {
            for (int i = 0; i < token.Length; i++)
                expIdx--;
        }
        void SyntaxErr(Errors error)
        {
            string[] err = { "Синтаксична помилка", 
                "Дисбаланс дужок", 
                "Вираз відсутній", 
                "Ділення на нуль", 
                "Рекурсивні посилання", 
                "Посилання на клітинку з помилкою", 
                "Посилання на неіснуючу клітинку" 
            };
            throw new ParserException(err[(int)error], currentRowCell, currentColCell);
        }
        void GetToken()
        {
            tokType = Types.NONE;
            token = "";
            //if (expIdx == exp.Length) return;
            while (expIdx < exp.Length && Char.IsWhiteSpace(exp[expIdx])) ++expIdx;
            if (expIdx == exp.Length) return;
            if (IsDelim(exp[expIdx]))
            {
                token += exp[expIdx];
                expIdx++;
                if (token == "m" || token == "d") expIdx += 2;
                if (token == "<" && (exp[expIdx] == '=' || exp[expIdx] == '>') || (token == ">" && exp[expIdx] == '=')) //string -> char
                {
                    token += exp[expIdx];
                    expIdx++;
                }
                tokType = Types.DELIMITER;
            }
            else if (Char.IsLetter(exp[expIdx]))
            {
                while (!IsDelim(exp[expIdx]))
                {
                    token += exp[expIdx];
                    expIdx++;
                    if (expIdx >= exp.Length) break;
                }

                char Column = token[0];
                string Row = token.Substring(1);
                int RowIndex;
                if (!int.TryParse(Row, out RowIndex)) SyntaxErr(Errors.SYNTAX);
                int rowIndex = RowIndex - 1;
                int columnIndex = (int)Column - 64 - 1;

                if (rowIndex >= Data.cells.Count || columnIndex >= Data.cells[rowIndex].Count)
                {
                    Cell notExistCell = new Cell() { RowNumber = rowIndex + 1, ColumnLetter = Column };
                    currentCell.References.Add(notExistCell);
                    SyntaxErr(Errors.NOTEXISTCELL);
                }

                Cell parsedCell = Data.cells[rowIndex][columnIndex];
                currentCell.References.Add(parsedCell);
                if (!string.IsNullOrEmpty(parsedCell.Error)) SyntaxErr(Errors.REFWITHERROR);

                token = parsedCell.Value.ToString();

                tokType = Types.NUMBER;
            }
            else if(Char.IsDigit(exp[expIdx]))
            {
                while (!IsDelim(exp[expIdx]))
                {
                    token += exp[expIdx];
                    expIdx++;
                    if (expIdx >= exp.Length) break;
                }
                tokType = Types.NUMBER;
            }
        }
        bool IsDelim(char c)
        {
            if ("+-md/*^<>=()".IndexOf(c) != -1) return true;
            return false;
        }
    }
}