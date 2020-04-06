using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VL1.Aids;
using VL1.Data.Quantity;
using VL1.Domain.Quantity;

namespace VL1.Infra.Quantity {

    public sealed class UnitFactorsRepository : PaginatedRepository<UnitFactor, UnitFactorData>, IUnitFactorsRepository {

        public UnitFactorsRepository() : this(null) { }
        public UnitFactorsRepository(QuantityDbContext c) : base(c, c?.UnitFactors) { }

        protected internal override UnitFactor toDomainObject(UnitFactorData d) => new UnitFactor(d);

        protected override async Task<UnitFactorData> getData(string id) {
            var systemOfUnitsId = GetString.Head(id);
            var unitId = GetString.Tail(id);

            return await dbSet.SingleOrDefaultAsync(x => x.SystemOfUnitsId == systemOfUnitsId && x.UnitId == unitId);
        }

        protected override string getId(UnitFactor obj) {
            return obj?.Data is null ? string.Empty : $"{obj.Data.SystemOfUnitsId}:{obj.Data.UnitId}";
        }

    }

}
