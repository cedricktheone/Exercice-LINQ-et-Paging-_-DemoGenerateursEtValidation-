namespace DemoGenerateursEtValidation.Models
{
    public class MemAutoRep : IAutoRep
    {
        private readonly DbAutoContext _dbAutoContext;
        private List<Auto> _MesAutos
        {
            get { 
                return _dbAutoContext.Autos.OrderBy(auto => auto.Model).ToList();
            }
            
        }


    

        public MemAutoRep(DbAutoContext dbAutoContext)
        {
            _dbAutoContext = dbAutoContext;
        }

        public IEnumerable<Auto> MesAuto
        {
            get { return _MesAutos; }
        }

        public void AddAuto(Auto auto)
        {
            _dbAutoContext.Autos.Add(auto);
            _dbAutoContext.SaveChanges();


        }

        public Auto GetAuto(int? id)
        {
            return _dbAutoContext.Autos.FirstOrDefault(auto => auto.Id == id);
        }

        void IAutoRep.SupprimerAuto(int id)
        {
            _dbAutoContext.Autos.Remove(GetAuto(id));
            _dbAutoContext.SaveChanges();
        }

        void IAutoRep.ModifierAuto(Auto auto)
        {
            _dbAutoContext.Autos.Remove(GetAuto(auto.Id));
            _dbAutoContext.Autos.Add(auto);
            _dbAutoContext.SaveChanges();
        }

    }
}
