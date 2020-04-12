namespace eu.rekawek.coffeegb
{
    public interface AddressSpace
    {
        bool accepts(int address);
        void setByte(int address, int value);
        int getByte(int address);
    }
}