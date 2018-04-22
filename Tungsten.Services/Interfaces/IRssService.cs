using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tungsten.Models.DomainModels;

namespace Tungsten.Services.Interfaces
{
    public interface IRssService
    {
        RssFeed GetRssFeed(string url);
    }
}
