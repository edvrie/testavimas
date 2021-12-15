using ObjektinisProgramuProjektavimas.Patterns.Factories;
using ObjektinisProgramuProjektavimas.Patterns.Iterator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjektinisProgramuProjektavimas.Patterns.Composite
{
    public class ItemComposite : IteratorAggregate, IComponent 
    {
        List<IComponent> componentList;
        IComponent item;
        bool _direction = false;
        public IComponent getItem()
        {
            return item;
        }

        public void add(IComponent item)
        {
            componentList.Add(item);
        }

        public void remove(Item item)
        {
            componentList.Remove(item);
        }

        public void createItem()
        {
            foreach(var component in componentList)
            {
                item = component.getItem();
            }
        }

        public List<IComponent> getItems()
        {
            return componentList;
        }

        public void ReverseDirection()
        {
            _direction = !_direction;
        }

        public override System.Collections.IEnumerator GetEnumerator()
        {
            return new CompositeIterator(this, _direction);
        }
    }
}
