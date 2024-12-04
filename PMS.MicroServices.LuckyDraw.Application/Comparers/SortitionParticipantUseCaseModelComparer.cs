using PMS.MicroServices.LuckyDraw.Application.Models;

namespace PMS.MicroServices.LuckyDraw.Application.Comparers;

public class SortitionParticipantUseCaseModelComparer : IComparer<SortitionParticipantUseCaseModel>
{
    public int Compare(SortitionParticipantUseCaseModel? x, SortitionParticipantUseCaseModel? y)
    {
        SortitionParticipantUseCaseModel c1 = x ?? new SortitionParticipantUseCaseModel();
        SortitionParticipantUseCaseModel c2 = y ?? new SortitionParticipantUseCaseModel();
        if (c1.Number > c2.Number)
            return 1;
        if (c1.Number < c2.Number)
            return -1;
        else
            return 0;
    }
}
