using KlxPiaoAPI;
using System.Text;

namespace 代码行数统计工具
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            SelectSln.LinkClicked += SelectSln_LinkClicked;
            SizeChanged += MainWindow_SizeChanged;

            MainWindow_SizeChanged(components, EventArgs.Empty);
        }

        private void MainWindow_SizeChanged(object? sender, EventArgs e)
        {
            ShowTextBox.Width = ClientRectangle.Width - ShowTextBox.Left * 2;
            ShowTextBox.Height = ClientRectangle.Height - ShowTextBox.Top - 40;
            panel1.Top = ShowTextBox.Bottom;
        }

        private void SelectSln_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog ofd = new()
            {
                Filter = "解决方案文件|*.sln"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var projects = GetSlnProject(ofd.FileName);
                    StringBuilder sb = new();

                    int allLineLength = 0;                //总行数

                    List<string> allLineLengths = [];     //全部的行长度文本（对齐排板用）
                    List<string> projectNames = [];       //全部的项目名称

                    List<List<string>> lineLengths = [];  //行数（按项目分）
                    List<List<string>> fileNames = [];    //文件名称（按项目分）
                    List<int> projectLineLengths = [];    //总行数（按项目分）

                    foreach (var project in projects)
                    {
                        List<string> addLineLengths = [];
                        List<string> addFileNames = [];
                        int addLineLength = 0;

                        projectNames.Add(project.Key);

                        foreach (string file in Directory.GetFiles(project.Value))
                        {
                            string fileName = Path.GetFileName(file);
                            string FileExten = Path.GetExtension(file);

                            if ((FileExten == ".vb" || FileExten == ".cs") &&
                                    !fileName.ToLower().EndsWith(".designer.vb", StringComparison.OrdinalIgnoreCase) &&
                                    !fileName.ToLower().EndsWith(".designer.cs", StringComparison.OrdinalIgnoreCase))
                            {
                                int lineLength = File.ReadAllLines(file).Length;

                                allLineLength += lineLength;               //添加到总行数
                                allLineLengths.Add(lineLength.ToString()); //添加到全部的行长度（对齐用）

                                addLineLength += lineLength;               //添加到总行数（按项目分）
                                addLineLengths.Add(lineLength.ToString());
                                addFileNames.Add(fileName);
                            }
                        }

                        lineLengths.Add(addLineLengths);
                        fileNames.Add(addFileNames);
                        projectLineLengths.Add(addLineLength);
                    }

                    int longLineText = allLineLengths.OrderByDescending(s => s.Length).First().Length;

                    for (int i = 0; i < projects.Count; i++)
                    {
                        sb.AppendLine($"{projectNames[i]} [{projectLineLengths[i]}]行");
                        for (int j = 0; j < lineLengths[i].Count; j++)
                        {
                            sb.Append($"[{lineLengths[i][j].PadRight(longLineText)}行] {fileNames[i][j]}");

                            if (j != lineLengths[i].Count - 1) sb.AppendLine();
                        }
                        if (i != projects.Count - 1) sb.AppendLine("\r\n");
                    }

                    ShowAllLineLengthTextBox.Text = allLineLength.ToString() + "行";
                    ShowTextBox.Text = sb.ToString();
                    ShowTextBox.Select(0, 0);
                    SelectSln.Text = ofd.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// 分析解决方案文件，返回项目名称和项目文件夹。
        /// </summary>
        /// <param name="filePath">解决方案文件路径。</param>
        /// <returns>分析后的项目信息，以 <see cref="Dictionary{TKey, TValue}"/> 表示。</returns>
        private static Dictionary<string, string> GetSlnProject(string filePath)
        {
            string content;

            if (!File.Exists(filePath)) throw new ArgumentException("指定的文件路径不存在。");

            try
            {
                content = File.ReadAllText(filePath);
            }
            catch
            {
                throw new Exception($"'{filePath}' 无法访问。");
            }

            List<string> projects = content.ExtractAllBetween("Project", "EndProject", MatchMode.StringIndex);

            if (projects.Count == 0) throw new Exception("指定的解决方案文件是空解决方案。");

            Dictionary<string, string> keyValuePairs = [];
            for (int i = 0; i < projects.Count; i++)
            {
                string[] parts = projects[i].Split(',');
                string part1 = parts[0];
                string part2 = parts[1];

                string name = part1[(part1.IndexOf('=') + 1)..].Trim().TrimStart('\"').TrimEnd('\"');
                string? slnParentPath = Path.GetDirectoryName(filePath);

                if (slnParentPath != null)
                {
                    string projectConfigFilePath = Path.Combine(slnParentPath, part2.Trim().TrimStart('\"').TrimEnd('\"'));

                    if (projectConfigFilePath.EndsWith(".csproj") || projectConfigFilePath.EndsWith(".vbproj"))
                    {
                        string path = Path.GetDirectoryName(projectConfigFilePath) ?? throw new Exception($"无法获取 '{projectConfigFilePath}' 所在的文件夹。");
                        keyValuePairs.Add(name, path);
                    }
                }
                else
                {
                    throw new Exception($"无法获取 '{filePath}' 所在的文件夹。");
                }
            }

            return keyValuePairs;
        }
    }
}