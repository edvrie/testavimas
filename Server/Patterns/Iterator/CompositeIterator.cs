using ObjektinisProgramuProjektavimas.Patterns.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjektinisProgramuProjektavimas.Patterns.Iterator
{
    public class CompositeIterator : Iterator
    {
        private ItemComposite _composite;

        private int _position = -1;

        private bool _reverse = false;

        public CompositeIterator(ItemComposite composite, bool reverse = false)
        {
            this._composite = composite;
            this._reverse = reverse;

            if (reverse)
            {
                this._position = _composite.getItems().Count;
            }
        }

        public override object Current()
        {
            return this._composite.getItems()[_position];
        }

        public override int Key()
        {
            return this._position;
        }

        public override bool MoveNext()
        {
            int updatedPosition = this._position + (this._reverse ? -1 : 1);

            if (updatedPosition >= 0 && updatedPosition < this._composite.getItems().Count)
            {
                this._position = updatedPosition;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Reset()
        {
            this._position = this._reverse ? this._composite.getItems().Count - 1 : 0;
        }
    }
}
