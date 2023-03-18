using UnityEngine;

namespace Scripts.Interfaces
{
    public interface ICollisionHandler
    {
        void OnCollisionEnter2D(Collision2D collision);

        void OnCollisionStay2D(Collision2D collision);

        void OnCollisionExit2D(Collision2D collision);
    }
}