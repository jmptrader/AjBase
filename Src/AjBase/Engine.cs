﻿namespace AjBase
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Engine
    {
        private Dictionary<string, Database> databases = new Dictionary<string, Database>();

        [ThreadStatic]
        private static Engine current;

        public static Engine Current
        {
            get
            {
                return current;
            }

            set
            {
                current = value;
            }
        }

        public Database CreateDatabase(string name)
        {
            if (this.databases.ContainsKey(name))
                throw new InvalidOperationException(string.Format("Database {0} already exists", name));

            Database db = new Database(this, name);

            this.databases[name] = db;

            return db;
        }

        public Database GetDatabase(string name)
        {
            if (!this.databases.ContainsKey(name))
                return null;

            return this.databases[name];
        }
    }
}
