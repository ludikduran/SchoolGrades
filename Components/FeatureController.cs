/*
' Copyright (c) 2013 Christoc.com
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using System.Collections.Generic;
using System.Xml;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;
using System;

namespace LD2.SchoolGrades.Components
{

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The Controller class for SchoolGrades
    /// 
    /// The FeatureController class is defined as the BusinessController in the manifest file (.dnn)
    /// DotNetNuke will poll this class to find out which Interfaces the class implements. 
    /// 
    /// The IPortable interface is used to import/export content from a DNN module
    /// 
    /// The ISearchable interface is used by DNN to index the content of a module
    /// 
    /// The IUpgradeable interface allows module developers to execute code during the upgrade 
    /// process for a module.
    /// 
    /// Below you will find stubbed out implementations of each, uncomment and populate with your own data
    /// </summary>
    /// -----------------------------------------------------------------------------

    //uncomment the interfaces to add the support.
    public class FeatureController : IPortable, ISearchable
    {
        #region Optional Interfaces

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// ExportModule implements the IPortable ExportModule Interface
        /// </summary>
        /// <param name="ModuleID">The Id of the module to be exported</param>
        /// -----------------------------------------------------------------------------
        public string ExportModule(int ModuleID)
        {
            string strXML = "";

            List<Classes> colSchoolGrades = new List<Classes>();
            foreach (Classes e in new ClassController().GetClasses())
            {
                colSchoolGrades.Add(e);
            }

            if (colSchoolGrades.Count != 0)
            {
                strXML += "<Subjects>";
                foreach (Classes e in colSchoolGrades)
                {
                    strXML += "<subject>";
                    strXML += "<subjectName>" + DotNetNuke.Common.Utilities.XmlUtils.XMLEncode(e.SubjectId.ToString()) + "</subjectName>";
                    strXML += "<subjectGrade>" + DotNetNuke.Common.Utilities.XmlUtils.XMLEncode(e.Grade) + "</subjectGrade>";
                    strXML += "<subjectComment>" + DotNetNuke.Common.Utilities.XmlUtils.XMLEncode(e.Comment) + "</subjectComment>";
                    strXML += "<studentId>" + DotNetNuke.Common.Utilities.XmlUtils.XMLEncode(e.StudentId.ToString()) + "</studentId>";
                    strXML += "</subject>";
                }
                strXML += "</Subjects>";
            }
            else
            {
                //return error: no content
                //DotNetNuke.UI.Skins.Skin.AddModuleMessage(this, "Error: No Content", DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.YellowWarning);
                throw new System.Exception("Error: No Content!");
            }

            return strXML;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// ImportModule implements the IPortable ImportModule Interface
        /// </summary>
        /// <param name="ModuleID">The Id of the module to be imported</param>
        /// <param name="Content">The content to be imported</param>
        /// <param name="Version">The version of the module to be imported</param>
        /// <param name="UserId">The Id of the user performing the import</param>
        /// -----------------------------------------------------------------------------
        public void ImportModule(int ModuleID, string Content, string Version, int UserID)
        {
            XmlNode xmlSchoolGradess = DotNetNuke.Common.Globals.GetContent(Content, "Subject");
            foreach (XmlNode xmlSchoolGrades in xmlSchoolGradess.SelectNodes("Subject"))
            {
                Classes objSchoolGrades = new Classes();
                objSchoolGrades.SubjectId = int.Parse(xmlSchoolGrades.SelectSingleNode("subjectName").InnerText);
                objSchoolGrades.Grade = xmlSchoolGrades.SelectSingleNode("subjectGrade").InnerText;
                objSchoolGrades.Comment = xmlSchoolGrades.SelectSingleNode("subjectComment").InnerText;
                objSchoolGrades.StudentId = int.Parse(xmlSchoolGrades.SelectSingleNode("studentId").InnerText);
                new ClassController().CreateClass(objSchoolGrades);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// GetSearchItems implements the ISearchable Interface
        /// </summary>
        /// <param name="ModInfo">The ModuleInfo for the module to be Indexed</param>
        /// -----------------------------------------------------------------------------
        public DotNetNuke.Services.Search.SearchItemInfoCollection GetSearchItems(DotNetNuke.Entities.Modules.ModuleInfo ModInfo)
        {
            SearchItemInfoCollection SearchItemCollection = new SearchItemInfoCollection();

            List<Classes> colSchoolGradess = new List<Classes>();
            foreach (Classes e in new ClassController().GetClasses())
            {
                colSchoolGradess.Add(e);
            }

            foreach (Classes objSchoolGrades in colSchoolGradess)
            {
                SearchItemInfo SearchItem2 = new SearchItemInfo(ModInfo.ModuleTitle, objSchoolGrades.SubjectId.ToString(), objSchoolGrades.StudentId, System.DateTime.Now, ModInfo.ModuleID, objSchoolGrades.StudentId.ToString(), "SubId=" + objSchoolGrades.SubjectId.ToString());
                SearchItemCollection.Add(SearchItem2);
            }

            return SearchItemCollection;

            //	throw new System.NotImplementedException("The method or operation is not implemented.");
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// UpgradeModule implements the IUpgradeable Interface
        /// </summary>
        /// <param name="Version">The current version of the module</param>
        /// -----------------------------------------------------------------------------
        //public string UpgradeModule(string Version)
        //{
        //	throw new System.NotImplementedException("The method or operation is not implemented.");
        //}

        #endregion
    }
}
