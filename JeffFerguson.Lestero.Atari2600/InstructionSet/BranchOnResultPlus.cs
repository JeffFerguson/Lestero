namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    internal class BranchOnResultPlus : InstructionWithByteOperand
    {
        internal BranchOnResultPlus(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.Relative, "BPL", 0x10, 2, 2)
        {
        }
    }
}
