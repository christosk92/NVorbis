using System;

namespace NVorbis.Contracts.Ogg
{
    interface IPageReader : IDisposable
    {
        void Lock();
        bool Release();

        long ContainerBits { get; }
        long WasteBits { get; }

        bool ReadNextPage();
        bool ReadLastPage(out int pageIndex);

        bool ReadPageAt(long offset);
    }
}
