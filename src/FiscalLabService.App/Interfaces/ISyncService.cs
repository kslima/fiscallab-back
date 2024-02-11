using FiscalLabService.App.Models;
using FiscalLabService.Shared.Responses;

namespace FiscalLabService.App.Interfaces;

public interface ISyncService
{
    Task<Result<SyncResult>> SyncDataASync(SyncModel syncModel);
}