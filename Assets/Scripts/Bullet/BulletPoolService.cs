using System.Collections.Generic;
using UnityEngine;

namespace SimpleShooty.Bullet
{
    public class BulletPoolService : MonoBehaviour
    {
        [SerializeField] private int poolSize, zero;
        [SerializeField] private BulletView bulletView;

        private Queue<BulletView> bulletQueue;

        protected virtual void Start()
        {
            bulletQueue = new Queue<BulletView>();

            InitializePool();
        }

        private void InitializePool()
        {
            for (int i = zero; i < poolSize; i++)
            {
                ReturnItem(CreateNewItem());
            }
        }

        public BulletView GetItem()
        {
            if (bulletQueue.Count == zero)
            {
                return CreateNewItem();
            }
            return bulletQueue.Dequeue();
        }

        private BulletView CreateNewItem()
        {
            BulletView item = Instantiate(bulletView);
            item.BulletPoolService = this;
            item.gameObject.SetActive(false);
            return item;
        }

        public void ReturnItem(BulletView item)
        {
            item.gameObject.SetActive(false);
            bulletQueue.Enqueue(item);
        }
    }
}