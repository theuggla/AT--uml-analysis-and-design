using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace MemberRegistry.model
{
   public class Persistance
    {
        /// <summary>
        /// Reads all the text of the given file.
        /// </summary>
        /// <param name="file">The file to read from.</param>
        /// <returns>A string containing all text of the file.</returns>
        private string GetText(string file)
        {
            return File.ReadAllText(file);
        }

        /// <summary>
        /// Writes a string to a file.
        /// </summary>
        /// <param name="file">The file to write to.</param>
        /// <param name="content">The string to write to the file</param>
        private void WriteTo(string file, string content)
        {
            File.WriteAllText(file, content);
        }

        /// <summary>
        /// Reads JSON from a file.
        /// </summary>
        /// <param name="file">The file to read from.</param>
        /// <returns>An object containing the contents of the file.</returns>
        public List<Member> ReadJson(string file)
        {
            var data = JsonConvert.DeserializeObject<List<Member>>(GetText(file));
            return data;
        }

        /// <summary>
        /// Writes JSON to a file.
        /// </summary>
        /// <param name="file">The file to write to.</param>
        /// <param name="content">The object to write to the file</param>
        public void WriteJson (string file, object content)
        {
            
            WriteTo(file, JsonConvert.SerializeObject(content, Formatting.Indented));
        }
    }
}