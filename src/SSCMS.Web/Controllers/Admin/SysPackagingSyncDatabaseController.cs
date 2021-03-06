﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSCMS.Core.Packaging;
using SSCMS.Utils;

namespace SSCMS.Web.Controllers.Admin
{
    [Route("sys/admin/packaging/sync/database")]
    public partial class SysPackagingSyncDatabaseController : ControllerBase
    {
        private const string Route = "";

        private readonly ISettingsManager _settingsManager;
        private readonly IPathManager _pathManager;
        private readonly IDatabaseManager _databaseManager;
        private readonly IPluginManager _pluginManager;

        public SysPackagingSyncDatabaseController(ISettingsManager settingsManager, IPathManager pathManager, IDatabaseManager databaseManager, IPluginManager pluginManager)
        {
            _settingsManager = settingsManager;
            _pathManager = pathManager;
            _databaseManager = databaseManager;
            _pluginManager = pluginManager;
        }

        [HttpPost, Route(Route)]
        public async Task<SubmitResult> Submit()
        {
            var idWithVersion = $"{PackageUtils.PackageIdSsCms}.{_settingsManager.ProductVersion}";
            var packagePath = _pathManager.GetPackagesPath(idWithVersion);
            var homeDirectory = _pathManager.GetHomeDirectoryPath(string.Empty);
            if (!DirectoryUtils.IsDirectoryExists(homeDirectory) || !FileUtils.IsFileExists(PathUtils.Combine(homeDirectory, "config.js")))
            {
                DirectoryUtils.Copy(PathUtils.Combine(packagePath, DirectoryUtils.HomeDirectoryName), homeDirectory, true);
            }

            await _databaseManager.SyncDatabaseAsync(_pluginManager);

            return new SubmitResult
            {
                Version = _settingsManager.ProductVersion
            };
        }
    }
}
