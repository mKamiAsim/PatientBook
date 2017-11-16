using System;
using System.Collections.Generic;
using System.Text;

namespace PatientBook.Core.Entity
{
    public class AppSettings
    {
        public Enum.ProviderType DbProvider { get; set; } = Enum.ProviderType.None;
        public string ConnectionName { get; set; }
        public string ConnectionString { get; set; }
        public int CommandTimeout { get; set; }

    }

    public class SessionObj
    {
        public static AppSettings AppSettings { get; set; }

    }
}
