using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tothdev.Placemap.Repository.Mapping
{
    public class PlacemapSurvey : EntityTypeConfiguration<Entity.PlacemapSurvey>
    {
        public PlacemapSurvey()
        {
            ToTable("PlacemapSurvey");
            HasKey(e => e.Id);

            Property(x => x.UpdateDate)
                .IsOptional();
        }
    }
}
