namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    internal class IncrementMemoryByOneAbsoluteX : InstructionWithWordOperand
    {
        internal IncrementMemoryByOneAbsoluteX(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.AbsoluteX, "INC", 0xFE, 3, 7)
        {
        }
    }
}
