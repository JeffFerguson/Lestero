namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    internal class RorAdcAbsoluteX : InstructionWithWordOperand
    {
        internal RorAdcAbsoluteX(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.AbsoluteX, "RRA", 0x7F, 3, 7)
        {
        }
    }
}
