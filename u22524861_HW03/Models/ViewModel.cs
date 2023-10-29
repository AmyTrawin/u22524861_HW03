using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u22524861_HW03.Models
{
    public class SavedReport
    {
        public string FileName { get; set; }
        public string Extension { get; set; }
    }
    public class ViewModel
    {
        public IPagedList<authors> authorList { get; set; }
        public IPagedList<books> bookList { get; set; }
        public IPagedList<borrows> borrowList { get; set; }
        public IPagedList<students> studentList { get; set; }
        public IPagedList<types> typeList { get; set; }

        public List<authors> authorList2 { get; set; }
        public List<books> bookList2 { get; set; }
        public List<borrows> borrowList2 { get; set; }
        public List<students> studentList2 { get; set; }
        public List<types> typeList2 { get; set; }

        public string FileName { get; set; }
        public string Extension { get; set; }
        public string ChartContent { get; set; }
    }
}