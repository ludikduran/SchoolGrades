﻿/*
' Copyright (c) 2013  Christoc.com
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using System;
using DotNetNuke.Entities.Modules;

namespace LD2.SchoolGrades
{
    public class SchoolGradesModuleBase : PortalModuleBase
    {
        public int SubjectId
        {
            get
            {
                var qs = Request.QueryString["subid"];
                if (qs != null)
                    return Convert.ToInt32(qs);
                return -1;
            }

        }

        public int StudentId
        {
            get
            {
                var qs = Request.QueryString["stuid"];
                if (qs != null)
                    return Convert.ToInt32(qs);
                return -1;
            }

        }

        public int ClassId
        {
            get
            {
                var qs = Request.QueryString["classid"];
                if (qs != null)
                    return Convert.ToInt32(qs);
                return -1;
            }
        }
    }
}