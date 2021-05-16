using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace VMTranslator
{
    public class Vm2Asm
    {
        private int SP = 256;

        private const int Pointer = 3;
        private const int Temp = 5;
        private const int Generous = 13;
        private const int Static = 16;

        private int tempSymbolCount = 0;

        private List<string> VMLines = new List<string>();
        private List<string> ASMLines = new List<string>();

        private int GetAddress(string name, string plus)
        {
            if (name == "constant")
            {
                return int.Parse(plus);
            }
            else if (name == "temp")
            {
                return Temp + int.Parse(plus);
            }
            else if (name == "static")
            {
                return Static + int.Parse(plus);
            }
            else if(name == "pointer")
            {
                return Pointer + int.Parse(plus);
            }
            return -1;
        }

        private void Push(string[] splitLine)
        {
            if (splitLine[1] == "constant")
            {
                ASMLines.Add("@" + GetAddress(splitLine[1], splitLine[2]));
                ASMLines.Add("D=A");
            }
            else if (splitLine[1] == "local")
            {
                ASMLines.Add("@" + splitLine[2]);
                ASMLines.Add("D=A");
                ASMLines.Add("@1");
                ASMLines.Add("A=D+M");
                ASMLines.Add("D=M");
            }
            else if (splitLine[1] == "argument")
            {
                ASMLines.Add("@" + splitLine[2]);
                ASMLines.Add("D=A");
                ASMLines.Add("@2");
                ASMLines.Add("A=D+M");
                ASMLines.Add("D=M");
            }
            else if(splitLine[1] == "this")
            {
                ASMLines.Add("@"+splitLine[2]);
                ASMLines.Add("D=A");
                ASMLines.Add("@3");
                ASMLines.Add("A=D+M");
                ASMLines.Add("D=M");
            }
            else if (splitLine[1] == "that")
            {
                ASMLines.Add("@" + splitLine[2]);
                ASMLines.Add("D=A");
                ASMLines.Add("@4");
                ASMLines.Add("A=D+M");
                ASMLines.Add("D=M");
            }
            else
            {
                ASMLines.Add("@" + GetAddress(splitLine[1], splitLine[2]));
                ASMLines.Add("D=M");
            }
                

            ASMLines.Add("@" + SP);
            ASMLines.Add("M=D");

            ASMLines.Add("@0");
            ASMLines.Add("M=M+1");
            SP++;
        }

        private void Pop(string[] splitLine)
        {
            if (splitLine[1] == "local")
            {
                ASMLines.Add("@" + splitLine[2]);
                ASMLines.Add("D=A");
                ASMLines.Add("@1");
                ASMLines.Add("D=D+M");
                ASMLines.Add("@T" + tempSymbolCount);
                ASMLines.Add("M=D");
                ASMLines.Add("@" + (SP - 1));
                ASMLines.Add("D=M");
                ASMLines.Add("@T" + tempSymbolCount);
                ASMLines.Add("A=M");

                tempSymbolCount++;
            }
            else if (splitLine[1] == "argument")
            {
                ASMLines.Add("@" + splitLine[2]);
                ASMLines.Add("D=A");
                ASMLines.Add("@2");
                ASMLines.Add("D=D+M");
                ASMLines.Add("@T" + tempSymbolCount);
                ASMLines.Add("M=D");
                ASMLines.Add("@" + (SP - 1));
                ASMLines.Add("D=M");
                ASMLines.Add("@T" + tempSymbolCount);
                ASMLines.Add("A=M");

                tempSymbolCount++;
            }
            else if (splitLine[1] == "this")
            {
                ASMLines.Add("@" + splitLine[2]);
                ASMLines.Add("D=A");
                ASMLines.Add("@3");
                ASMLines.Add("D=D+M");
                ASMLines.Add("@T" + tempSymbolCount);
                ASMLines.Add("M=D");
                ASMLines.Add("@" + (SP - 1));
                ASMLines.Add("D=M");
                ASMLines.Add("@T" + tempSymbolCount);
                ASMLines.Add("A=M");

                tempSymbolCount++;
            }
            else if (splitLine[1] == "that")
            {
                ASMLines.Add("@" + splitLine[2]);
                ASMLines.Add("D=A");
                ASMLines.Add("@4");
                ASMLines.Add("D=D+M");
                ASMLines.Add("@T" + tempSymbolCount);
                ASMLines.Add("M=D");
                ASMLines.Add("@" + (SP - 1));
                ASMLines.Add("D=M");
                ASMLines.Add("@T" + tempSymbolCount);
                ASMLines.Add("A=M");

                tempSymbolCount++;
            }
            else
            {
                ASMLines.Add("@" + (SP - 1));
                ASMLines.Add("D=M");
                ASMLines.Add("@" + GetAddress(splitLine[1], splitLine[2]));
            }

            ASMLines.Add("M=D");

            ASMLines.Add("@0");
            ASMLines.Add("M=M-1");
            SP--;
        }

        private void Add()
        {
            ASMLines.Add("@" + (SP - 2));
            ASMLines.Add("D=M");
            ASMLines.Add("@" + (SP - 1));
            ASMLines.Add("D=D+M");
            ASMLines.Add("@" + (SP - 2));
            ASMLines.Add("M=D");

            ASMLines.Add("@0");
            ASMLines.Add("M=M-1");
            SP--;
        }

        private void Sub()
        {
            ASMLines.Add("@" + (SP - 2));
            ASMLines.Add("D=M");
            ASMLines.Add("@" + (SP - 1));
            ASMLines.Add("D=D-M");
            ASMLines.Add("@" + (SP - 2));
            ASMLines.Add("M=D");

            ASMLines.Add("@0");
            ASMLines.Add("M=M-1");
            SP--;
        }

        private void Neg()
        {
            ASMLines.Add("@" + (SP - 1));
            ASMLines.Add("M=-M");
        }

        private void Eq()
        {
            ASMLines.Add("@" + (SP - 2));
            ASMLines.Add("D=M");
            ASMLines.Add("@" + (SP - 1));
            ASMLines.Add("D=D-M");

            ASMLines.Add("@EQ" + tempSymbolCount);
            ASMLines.Add("D;JEQ");
            ASMLines.Add("@" + (SP - 2));
            ASMLines.Add("M=0");
            ASMLines.Add("@EQEND" + tempSymbolCount);
            ASMLines.Add("0;JMP");

            ASMLines.Add("(EQ" + tempSymbolCount + ")");
            ASMLines.Add("@" + (SP - 2));
            ASMLines.Add("M=-1");

            ASMLines.Add("(EQEND" + tempSymbolCount + ")");

            ASMLines.Add("@0");
            ASMLines.Add("M=M-1");
            SP--;
            tempSymbolCount++;
        }

        private void Gt()
        {
            ASMLines.Add("@" + (SP - 2));
            ASMLines.Add("D=M");
            ASMLines.Add("@" + (SP - 1));
            ASMLines.Add("D=D-M");

            ASMLines.Add("@GT" + tempSymbolCount);
            ASMLines.Add("D;JGT");
            ASMLines.Add("@" + (SP - 2));
            ASMLines.Add("M=0");
            ASMLines.Add("@GTEND" + tempSymbolCount);
            ASMLines.Add("0;JMP");

            ASMLines.Add("(GT" + tempSymbolCount + ")");
            ASMLines.Add("@" + (SP - 2));
            ASMLines.Add("M=-1");

            ASMLines.Add("(GTEND" + tempSymbolCount + ")");

            ASMLines.Add("@0");
            ASMLines.Add("M=M-1");
            SP--;
            tempSymbolCount++;
        }

        private void Lt()
        {
            ASMLines.Add("@" + (SP - 2));
            ASMLines.Add("D=M");
            ASMLines.Add("@" + (SP - 1));
            ASMLines.Add("D=D-M");

            ASMLines.Add("@LT" + tempSymbolCount);
            ASMLines.Add("D;JLT");
            ASMLines.Add("@" + (SP - 2));
            ASMLines.Add("M=0");
            ASMLines.Add("@LTEND" + tempSymbolCount);
            ASMLines.Add("0;JMP");

            ASMLines.Add("(LT" + tempSymbolCount + ")");
            ASMLines.Add("@" + (SP - 2));
            ASMLines.Add("M=-1");

            ASMLines.Add("(LTEND" + tempSymbolCount + ")");

            ASMLines.Add("@0");
            ASMLines.Add("M=M-1");
            SP--;
            tempSymbolCount++;
        }

        private void And()
        {
            ASMLines.Add("@" + (SP - 2));
            ASMLines.Add("D=M");
            ASMLines.Add("@" + (SP - 1));
            ASMLines.Add("D=D&M");
            ASMLines.Add("@" + (SP - 2));
            ASMLines.Add("M=D");

            ASMLines.Add("@0");
            ASMLines.Add("M=M-1");
            SP--;
        }

        private void Or()
        {
            ASMLines.Add("@" + (SP - 2));
            ASMLines.Add("D=M");
            ASMLines.Add("@" + (SP - 1));
            ASMLines.Add("D=D|M");
            ASMLines.Add("@" + (SP - 2));
            ASMLines.Add("M=D");

            ASMLines.Add("@0");
            ASMLines.Add("M=M-1");
            SP--;
        }

        private void Not()
        {
            ASMLines.Add("@" + (SP - 1));
            ASMLines.Add("M=!M");
        }

        public void Translate()
        {
            foreach (string vmLine in VMLines)
            {
                string[] splitLine = vmLine.Split(' ');
                if (splitLine[0] == "push")
                {
                    ASMLines.Add("//push " + splitLine[1] + " " + splitLine[2]);
                    Push(splitLine);
                }
                else if (splitLine[0] == "pop")
                {
                    ASMLines.Add("//pop " + splitLine[1] + " " + splitLine[2]);
                    Pop(splitLine);
                }
                else if (splitLine[0] == "add")
                {
                    ASMLines.Add("//add");
                    Add();
                }
                else if (splitLine[0] == "sub")
                {
                    ASMLines.Add("//sub");
                    Sub();
                }
                else if (splitLine[0] == "neg")
                {
                    ASMLines.Add("//neg");
                    Neg();
                }
                else if (splitLine[0] == "eq")
                {
                    ASMLines.Add("//eq");
                    Eq();
                }
                else if (splitLine[0] == "gt")
                {
                    ASMLines.Add("//gt");
                    Gt();
                }
                else if (splitLine[0] == "lt")
                {
                    ASMLines.Add("//lt");
                    Lt();
                }
                else if (splitLine[0] == "and")
                {
                    ASMLines.Add("//and");
                    And();
                }
                else if (splitLine[0] == "or")
                {
                    ASMLines.Add("//or");
                    Or();
                }
                else if (splitLine[0] == "not")
                {
                    ASMLines.Add("//not");
                    Not();
                }
                else
                {
                    continue;
                }
                ASMLines.Add("");
            }
        }

        public void ReadFile(string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.Default);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                VMLines.Add(line);
            }
            sr.Close();
        }

        public void PrintFlie()
        {
            foreach (string asmLine in ASMLines)
            {
                Console.WriteLine(asmLine);
            }
            Console.ReadKey();
        }

        public void SaveFile(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            foreach (string asmLine in ASMLines)
            {
                sw.WriteLine(asmLine);
            }
            sw.Flush();
            sw.Close();
            fs.Close();
        }
    }

    class VMTranslator
    {
        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                //本地测试用代码
                String path = Directory.GetCurrentDirectory();
                string[] filenames = Directory.GetFiles(path);
                var files = Directory.GetFiles(path, "*.vm");

                foreach (var file in files)
                {
                    Vm2Asm vm2asm = new Vm2Asm();
                    vm2asm.ReadFile(file);
                    vm2asm.Translate();
                    vm2asm.SaveFile(file.Replace(".vm", ".asm"));
                }
            }
            else
            {
                //评分用代码
                string file = args[0];

                Vm2Asm vm2asm = new Vm2Asm();
                vm2asm.ReadFile(file);
                vm2asm.Translate();
                vm2asm.SaveFile(file.Replace(".vm", ".asm"));
            }
        }
    }
}
