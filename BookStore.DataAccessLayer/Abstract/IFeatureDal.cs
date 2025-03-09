﻿using BookStore.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccessLayer.Abstract
{
    public interface IFeatureDal :IGenericDal<Feature>
    {
        int GetFeatureCount();
    }
}
