using System;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace WinWebSolution.Module {
    [DeferredDeletion(false)]
    [DefaultClassOptions]
    public class Neighbour : BaseObject {
        public Neighbour(Session session) : base(session) { }
        private string _name;
        public string Name {
            get { return _name; }
            set { SetPropertyValue("Name", ref _name, value); }
        }
        private Master _master;
        public Master Master {
            get { return _master; }
            set { SetPropertyValue("Master", ref _master, value); }
        }
    }
}