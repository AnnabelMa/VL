using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VL1.Aids;
using VL1.Data.Quantity;
using VL1.Domain.Quantity;

namespace VL1.Infra.Quantity {

    public sealed class UnitTermsRepository : PaginatedRepository<UnitTerm, UnitTermData>, IUnitTermsRepository {

        public UnitTermsRepository() : this(null) { }

        public UnitTermsRepository(QuantityDbContext c) : base(c, c?.UnitTerms) { }

        protected internal override UnitTerm toDomainObject(UnitTermData d) => new UnitTerm(d);

        protected override async Task<UnitTermData> getData(string id) {
            var masterId = GetString.Head(id);
            var termId = GetString.Tail(id);

            return await dbSet.SingleOrDefaultAsync(x => x.TermId == termId && x.MasterId == masterId);
        }

        protected override string getId(UnitTerm obj) {
            return obj?.Data is null ? string.Empty : $"{obj.Data.MasterId}.{obj.Data.TermId}";
        }
    }
}

