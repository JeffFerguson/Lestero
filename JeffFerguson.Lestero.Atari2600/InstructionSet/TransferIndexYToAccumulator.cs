namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    internal class TransferIndexYToAccumulator : Instruction
    {
        internal TransferIndexYToAccumulator(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.Implied, "TYA", 0x98, 1, 2)
        {
        }
    }
}
