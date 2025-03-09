using BookStore.BusinessLayer.Abstract;
using BookStore.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLayer.Concrete
{
    public class FeatureManager : IFeatureService
    {
        private readonly IFeatureService _featureService;

        public FeatureManager(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public void TAdd(Feature entity)
        {
            _featureService.TAdd(entity);
        }

        public void TDelete(int id)
        {
            _featureService.TDelete(id);
        }

        public List<Feature> TGetAll()
        {
            return _featureService.TGetAll();
        }

        public Feature TGetById(int id)
        {
            return _featureService.TGetById(id);
        }

        public void TUpdate(Feature entity)
        {
            _featureService.TUpdate(entity);
        }
    }
}
