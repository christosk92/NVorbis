using System;

namespace NVorbis.Contracts.Ogg
{
    interface IStreamPageReader
    {
        IPacketProvider PacketProvider { get; }

        void AddPage();

        Memory<byte>[] GetPagePackets(int pageIndex);

        int FindPage(long granulePos);

        bool GetPage(int pageIndex, out long granulePos, out bool isResync, out bool isContinuation, out bool isContinued, out int packetCount, out int pageOverhead);
        bool GetLastPage();
        void SetEndOfStream();

        int PageCount { get; }

        bool HasAllPages { get; }

        long? MaxGranulePosition { get; }
        
        long? ActualMaxGranulePosition { get; }

        int FirstDataPageIndex { get; }
    }
}
