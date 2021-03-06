﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static LiteDB.Constants;

namespace LiteDB.Engine
{
    public partial class LiteEngine
    {
        /// <summary>
        /// Register all internal system collections avaiable by default
        /// </summary>
        private void InitializeSystemCollections()
        {
            this.RegisterSystemCollection("$database", () => this.SysDatabase());

            this.RegisterSystemCollection("$cols", () => this.SysCols());
            this.RegisterSystemCollection("$indexes", () => this.SysIndexes());

            this.RegisterSystemCollection("$sequences", () => this.SysSequences());

            this.RegisterSystemCollection("$transactions", () => this.SysTransactions());
            this.RegisterSystemCollection("$snapshots", () => this.SysSnapshots());
            this.RegisterSystemCollection("$open_cursors", () => this.SysOpenCursors());

            this.RegisterSystemCollection(new SysFileJson());
            this.RegisterSystemCollection(new SysFileCsv());
            this.RegisterSystemCollection(new SysDump(_header, this));
            this.RegisterSystemCollection(new SysPageList(_header, this));

            this.RegisterSystemCollection(new SysQuery(this));
        }
    }
}