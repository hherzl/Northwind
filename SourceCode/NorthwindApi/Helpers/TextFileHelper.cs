using System;
using System.IO;
using System.Text;

namespace NorthwindApi.Helpers
{
    public static class TextFileHelper
    {
        public static void Create(String path, String data, FileMode mode, FileAccess access, Encoding encoding)
        {
            FileStream file = null;

            StreamWriter stream = null;

            try
            {
                file = new FileStream(path, mode, access);

                stream = new StreamWriter(file, encoding);

                stream.Write(data);
            }
            catch
            {
                throw;
            }
            finally
            {
                stream.Close();
            }
        }

        public static void Append(String path, String data, Encoding enconding)
        {
            Create(path, data, FileMode.Append, FileAccess.Write, enconding);
        }

        public static void Create(String path, String data, Encoding enconding)
        {
            Create(path, data, FileMode.Create, FileAccess.Write, enconding);
        }

        public static String Read(String path, FileMode mode, FileAccess access, Encoding encoding)
        {
            FileStream file = null;

            StreamReader reader = null;

            StringBuilder builder = new StringBuilder();

            try
            {
                file = new FileStream(path, mode, access);

                reader = new StreamReader(file, encoding);

                while (reader.Peek() != -1)
                {
                    builder.Append(reader.ReadLine());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                reader.Close();
            }

            return builder.ToString();
        }
    }
}
