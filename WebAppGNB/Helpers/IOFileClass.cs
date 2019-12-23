using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
 

namespace WebApiGNB.Helpers
{
    public class IOFileClass
    {
        public IOFileClass()
        {

        }

        public string CreateDir(string pathroot)
        {            
            Directory.CreateDirectory(pathroot);
            return pathroot;
        }

        public void Createfile(string path, string filename)
        {
            if (!Existfile(path,filename))
            {
             var myFile =  File.Create(string.Concat(path,@"\",filename));
             myFile.Close();
            }
           
        }
 

        public List<string> ReadfileData(string filename)
        {
            var listLines = new List<string>();
            string line;
            StreamReader fileStream = new  StreamReader(filename);

            while ((line = fileStream.ReadLine()) != null)
            {
                listLines.Add(line);
            }
            if (fileStream != null) fileStream.Close();
            return listLines;
            
        }

        public void WritefileData(string filename,List<string> Data)
        {      
            StreamWriter  fileStream = new StreamWriter(filename, append: true);

            fileStream.WriteLine("[");
            foreach (var item in Data)
            {
                fileStream.WriteLine(item);
            }
            fileStream.WriteLine("]");
            if (fileStream != null)
                fileStream.Flush();
                fileStream.Close();
     
        }

        public void Deletefiles(string pathRoot)
        {
            if(ExistsDir(pathRoot))
            {
            List<string> files = Directory.GetFiles(pathRoot, "*.*", SearchOption.AllDirectories).ToList();
            foreach (string item in files)
            {
                System.IO.File.Delete(item);
            }
            Directory.Delete(pathRoot, true);
            }
            
             
        }

        public bool Existfile(string path, string filename)
        {
            List<string> files = Directory.GetFiles(path, @"*.*", SearchOption.AllDirectories).ToList();
            bool res = false;

            foreach (string item in files)
            {
                if (Path.GetFileNameWithoutExtension(item) == Path.GetFileNameWithoutExtension(filename))
                {
                    res = true;
                }

            }
            return res;
        }

        public bool ExistsDir(string path)
        {
           if ( Directory.Exists(path))
            {return true; }
            else { return false; }
            
        }

    }   
}