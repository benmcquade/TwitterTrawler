using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml.Linq;
using TwitterTrawler.Models;

namespace TwitterTrawler.Repository
{
    public class ArchiveRepository
    {
        /// <summary>
        /// Method that creates the file and populates it with the serialised archive object
        /// </summary>
        /// <param name="archive">object content the data ready for archiving</param>
        /// <returns>true if sucessful, false if not</returns>
        public bool ArchiveResponse(Archive archive)
        {
            try
            {
                var path = $"/Logs/{archive.Timestamp}";
                File.WriteAllText(path, new JavaScriptSerializer().Serialize(archive));

                return true;
            }
            catch (Exception)
            {
                // given more time i would log the error here
                return false;
            }
        }
    }
}
