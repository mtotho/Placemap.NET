using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tothdev.Placemap.Repository.Mapping
{
    public class PlacemapType : EntityTypeConfiguration<Entity.PlacemapType>
    {
        public PlacemapType()
        {
            ToTable("PlacemapType");
            HasKey(e => e.Id);

            Property(x => x.UpdateDate)
                .IsOptional();
        }
    }
}
