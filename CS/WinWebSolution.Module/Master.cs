using System;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo.Metadata;
using System.Collections;

namespace WinWebSolution.Module {
    [DefaultClassOptions]
    [DeferredDeletion(false)]
    public class Master : BaseObject {
        public Master(Session session) : base(session) { }
        [Association("Master-Children"), Aggregated]
        public XPCollection<Child> Children {
            get {
                return GetCollection<Child>("Children");
            }
        }
        private string _name;
        public string Name {
            get { return _name; }
            set { SetPropertyValue("Name", ref _name, value); }
        }
        protected override void OnDeleting() {
            ICollection objs = Session.CollectReferencingObjects(this);
            if (objs.Count > 0) {
                foreach (XPMemberInfo mi in ClassInfo.CollectionProperties) {
                    if (mi.IsAggregated && mi.IsCollection && mi.IsAssociation) {
                        foreach (IXPObject obj in objs) {
                            if (((XPBaseCollection)mi.GetValue(this)).BaseIndexOf(obj) < 0) {
                                throw new InvalidOperationException("The object cannot be deleted. Other objects have references to it.");
                            }
                        }
                    }
                }
            }
            base.OnDeleting();
        }
    }
}