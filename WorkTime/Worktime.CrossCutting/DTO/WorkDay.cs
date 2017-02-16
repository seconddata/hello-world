using System;
using WorkTime.Interface;

namespace WorkTime.CrossCutting.DTO
{
    public class WorkDay : IWorkDay
    {
        public int Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Remark { get; set; }

    }
}
