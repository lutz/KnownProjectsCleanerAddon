using SwissAcademic.Citavi;
using SwissAcademic.Citavi.Shell;
using System;

namespace KnownProjectsCleaner
{
    public class Addon : CitaviAddOn<MainForm>
    {
        #region Constructors

        public Addon() => CleanKnownProjectCollections();

        #endregion

        #region Methods

        void CleanKnownProjectCollections()
        {
            for (int i = Program.Engine.Settings.General.KnownProjects.Count-1; i >= 0; i--)
            {
                var knownProject = Program.Engine.Settings.General.KnownProjects[i];
                if (knownProject.ProjectType != ProjectType.DesktopSQLite) continue;
                if(knownProject.ConnectionString.EndsWith(".ctv6", StringComparison.OrdinalIgnoreCase) && !System.IO.File.Exists(knownProject.ConnectionString))
                    Program.Engine.Settings.General.KnownProjects.Remove(knownProject);
            }
        }

        #endregion

    }
}