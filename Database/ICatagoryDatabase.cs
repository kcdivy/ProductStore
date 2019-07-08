using ProductQueryModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public interface ICatagoryDatabase: IDatabase<Catagory>
    {
        Catagory GetByName(object name, string connectionString);
    }
}
