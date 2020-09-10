using System;
using System.Collections.Generic;
using System.Text;

namespace Net.Light.Framework.CodeGeneration.Source.BO
{
    internal struct Table
    {
        public string NameSpace { get; set; }

        public string TableName { get; set; }

        public string IdColumn { get; set; }

        public List<Column> TableColumns { get; set; }

        public override string ToString()
        {
            try
            {
                StringBuilder boBuilder = new StringBuilder();
                boBuilder.AppendLine(Constants.USING_Base);
                boBuilder.AppendLine(Constants.USING_BaseBO);
                boBuilder.AppendLine("using System;");
                boBuilder.Append("using ");
                boBuilder.AppendFormat(Constants.DL_NAMESPACE_FORMAT, NameSpace);
                boBuilder.AppendLine(";");
                boBuilder.AppendLine();
                boBuilder.AppendFormat("namespace {0}\n", string.Format(Constants.BO_NAMESPACE_FORMAT, NameSpace));
                boBuilder.AppendLine("{");
                boBuilder.AppendFormat("\tpublic class {0} : {1}\n", TableName.Replace(" ", ""), Constants.BaseBO);
                boBuilder.Append("\t{\n");

                boBuilder.AppendFormat("\t\tpublic {0}()", TableName.Replace(" ", "")).AppendLine();
                boBuilder.AppendLine("\t\t{");
                boBuilder.AppendFormat("\t\t\ttableProp.TableName = \"{0}\";", TableName).AppendLine();
                boBuilder.AppendFormat("\t\t\ttableProp.IdCol = \"{0}\";", IdColumn).AppendLine();
                boBuilder.AppendLine("\t\t}").AppendLine();
                string str;

                foreach (Column col in TableColumns)
                {
                    str = col.ToString();
                    boBuilder.Append(str);
                    str = "";
                }

                boBuilder.AppendLine();
                boBuilder.AppendLine(MethodString("int", "Insert"));
                boBuilder.AppendLine(MethodString("int", "InsertAndGetId"));
                boBuilder.AppendLine(MethodString("int", "Update"));
                boBuilder.AppendLine(MethodString("int", "Delete"));

                boBuilder.AppendLine("\t}");
                boBuilder.Append("}");
                return boBuilder.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string ToDLString()
        {
            try
            {
                StringBuilder dlBuilder = new StringBuilder();
                dlBuilder.AppendLine("using System;");
                dlBuilder.AppendLine(string.Format("{0}", Constants.USING_Base));
                dlBuilder.AppendLine(string.Format("{0}", Constants.USING_BaseDL)).AppendLine();
                dlBuilder.AppendFormat("namespace {0}\n", string.Format(Constants.DL_NAMESPACE_FORMAT, NameSpace));
                dlBuilder.AppendLine("{");

                dlBuilder.AppendFormat("\tinternal class {0}DL : {1}\n", TableName.Replace(" ", ""), Constants.BaseDL);
                dlBuilder.AppendLine("\t{");

                dlBuilder.AppendFormat("\t\tinternal {0}DL()\n", TableName.Replace(" ", ""));
                dlBuilder.AppendLine("\t\t\t: base()");
                dlBuilder.AppendLine("\t\t{\n\t\t}");

                dlBuilder.Append("\t}\n}");
                return dlBuilder.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string MethodString(string returnType, string methodName)
        {
            StringBuilder mthdBuilder = new StringBuilder();

            mthdBuilder.AppendFormat("\t\tinternal {0} {1}()\n\t\t", returnType, methodName);

            mthdBuilder.AppendLine("{");
            // starting try block
            mthdBuilder.AppendLine("\t\t\ttry\n\t\t\t{");
            mthdBuilder.AppendFormat("\t\t\t\tusing({0}DL _{1}dlDL = new {0}DL())\n", TableName.Replace(" ", ""), TableName.Replace(" ", "").ToLower());
            mthdBuilder.AppendLine("\t\t\t\t{");
            mthdBuilder.AppendFormat("\t\t\t\t\treturn _{0}dlDL.{1}(this);\n", TableName.Replace(" ", "").ToLower(), methodName);
            mthdBuilder.AppendLine("\t\t\t\t}");
            // ending try block
            mthdBuilder.AppendLine("\t\t\t}");
            // starting-ending catch block
            mthdBuilder.AppendLine("\t\t\tcatch (Exception)\n\t\t\t{\n\t\t\t\tthrow;\n\t\t\t}");
            mthdBuilder.AppendLine("\t\t}");

            return mthdBuilder.ToString();
        }
    }
}
