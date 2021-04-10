using System;
using System.Collections.Generic;
using System.Text;

namespace BootCampV2.Homeworks.ThirdWeek
{
    public interface ICommand
    {
        string Prefix { get; }

        string Description { get; }

        void Execute(List<string> parameter);
    }
}
