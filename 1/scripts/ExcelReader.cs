using System.Collections.Generic;
using System.IO;
using ExcelDataReader;
using System.Text;

public class ExcelReader
{
    public struct ExcelData//创建一个结构体
    {
        public string speakerName;//
        public string speakingContent;
        public string avatarImageFileName;
        public string vocalAudioFileName;
        public string backgroundImageFileName;//5
        public string backgroundMusicFileName;
        //截止

        public string character1Action;
        public string coordinateX1;
        public string character1ImageFileName;
        public string character2Action;//10
        public string coordinateX2;
        public string character2ImageFileName;
        public string 上次背景;//11
        public string 上次音乐;
        public string 上次位置1;
        public string 上次位置2;
        public string hualangjihao;

    }

    public static List<ExcelData> ReadExcel(string filePath)//静态方法接受一个文件链接返回一个列表。
    {
        List<ExcelData> excelData = new List<ExcelData>();//创建一个exceData变量
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);//加载库中类，让字符可识别。?????
        using(var stream = File.Open(filePath, FileMode.Open,FileAccess.Read))//以只读打开文件，这个没学
        {
            using(var reader = ExcelReaderFactory.CreateReader(stream))//使用库创建一个EXCEL阅读器
            {
                do
                {
                    while (reader.Read())//读取一行，这是ExcelReaderFactory提供的功能
                    {
                        ExcelData data = new ExcelData();
                        data.speakerName = reader.IsDBNull(0) ? string.Empty : reader.GetValue(0)?.ToString();
                        data.speakingContent = reader.IsDBNull(1) ? string.Empty : reader.GetValue(1)?.ToString();
                        data.avatarImageFileName = reader.IsDBNull(2) ? string.Empty : reader.GetValue(2)?.ToString();
                        data.vocalAudioFileName = reader.IsDBNull(3) ? string.Empty : reader.GetValue(3)?.ToString();
                        data.backgroundImageFileName = reader.IsDBNull(4) ? string.Empty : reader.GetValue(4)?.ToString();
                        data.backgroundMusicFileName = reader.IsDBNull(5) ? string.Empty : reader.GetValue(5)?.ToString();
                        data.character1Action = reader.IsDBNull(6) ? string.Empty : reader.GetValue(6)?.ToString();
                        //分水

                        data.coordinateX1 = reader.IsDBNull(7) ? string.Empty : reader.GetValue(7)?.ToString();
                        data.character1ImageFileName = reader.IsDBNull(8) ? string.Empty : reader.GetValue(8)?.ToString();
                        data.character2Action = reader.IsDBNull(9) ? string.Empty : reader.GetValue(9)?.ToString();
                        data.coordinateX2 = reader.IsDBNull(10) ? string.Empty : reader.GetValue(10)?.ToString();
                        data.character2ImageFileName = reader.IsDBNull(11) ? string.Empty : reader.GetValue(11)?.ToString();
                        data.上次背景 = reader.IsDBNull(12) ? string.Empty : reader.GetValue(12)?.ToString();
                        data.上次音乐 = reader.IsDBNull(13) ? string.Empty : reader.GetValue(13)?.ToString();
                        data.上次位置1 = reader.IsDBNull(14) ? string.Empty : reader.GetValue(14)?.ToString();
                        data.上次位置2 = reader.IsDBNull(15) ? string.Empty : reader.GetValue(15)?.ToString();
                        data.hualangjihao = reader.IsDBNull(16) ? string.Empty : reader.GetValue(16)?.ToString();
                        excelData.Add(data);
                    }
                }while (reader.NextResult());//下一个表，但我们现在只有一个表。//现在是有多个表了，但没改
            }
        }
        return excelData;
    }


}