namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    internal class ShiftLeftOneBitAccumulator : Instruction
    {
        internal ShiftLeftOneBitAccumulator(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.Accumulator, "ASL", 0x0A, 1, 2)
        {
        }
    }
}
