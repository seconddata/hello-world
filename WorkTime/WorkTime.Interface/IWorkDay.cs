using System;

namespace WorkTime.Interface
{
    public interface IWorkDay
    {
        int Id { get; set; }
        DateTime StartDateTime { get; set; }
        DateTime EndDateTime { get; set; }
        string Remark { get; set; }

    }
}
