// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

namespace UnityEditor.PackageManager.UI.Internal
{
    internal class UpdateFoldout : MultiSelectFoldout
    {
        private static readonly string k_UpdateInfoTextFormat = L10n.Tr("Version {0} available");

        public UpdateFoldout(IApplicationProxy applicationProxy,
                             IPackageDatabase packageDatabase,
                             IPackageOperationDispatcher operationDispatcher,
                             IPageManager pageManager)
            : base(new UpdateAction(operationDispatcher, applicationProxy, packageDatabase, pageManager))
        {
        }

        protected override MultiSelectItem CreateMultiSelectItem(IPackageVersion version)
        {
            var rightInfoText = string.Format(k_UpdateInfoTextFormat, version?.package?.versions.GetUpdateTarget(version).versionString);
            return new MultiSelectItem(version, rightInfoText);
        }
    }
}
