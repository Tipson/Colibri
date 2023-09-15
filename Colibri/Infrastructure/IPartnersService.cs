using Colibri.Infrastructure.DbContext.Entities;
using Colibri.Models.Commands.Partners;
using Colibri.Models.Partners;

namespace Colibri.Infrastructure;

public interface IPartnersService
{
    Task<Partner> Get(GetPartnerCommand command, CancellationToken token);
    Task<PartnersGroupedCollection> GetGrouped(GetGroupedPartnerCommand command, CancellationToken token);
    Task<PartnerRow> GetAsRow(GetAsRowPartnerCommand command, CancellationToken token);
    Task<IEnumerable<Partner>> GetAll(GetAllPartnerCommand command, CancellationToken token);
    Task<Partner> Create(CreatePartnerCommand command, CancellationToken token);
    Task<Partner> Update(UpdatePartnerCommand command, CancellationToken token);
    Task Delete(DeletePartnerCommand command,CancellationToken token);
    Task<Partner> UpdateVisibility(UpdateVisibilityPartnerCommand command, CancellationToken token);


}