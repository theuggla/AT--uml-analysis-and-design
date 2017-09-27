using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace MemberRegistry.persistance
{
   public class JSONFilePersistance : IPersistance
    {
        private string _pathToFile;

        public JSONFilePersistance(string pathToFile)
        {
            this._pathToFile = pathToFile;
        }


        public List<model.Member> RetrieveMemberList()
        {
            var data = JsonConvert.DeserializeObject<List<model.Member>>(GetText(this._pathToFile));
            return data;
        }

        public void SaveMemberList(List<model.Member> content)
        {
            
            WriteTo(this._pathToFile, JsonConvert.SerializeObject(content, Formatting.Indented));
        }
        
        private string GetText(string file)
        {
            return File.ReadAllText(file);
        }

        private void WriteTo(string file, string content)
        {
            File.WriteAllText(file, content);
        }
    }
}