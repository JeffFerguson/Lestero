using JeffFerguson.Lestero.Atari2600.InstructionSet;
using System;

namespace JeffFerguson.Lestero.Atari2600
{
    /// <summary>
    /// A virtual machine for the Atari 2600.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The memory map for the Atari 2600 is as follows:
    /// <list type="bullet">
    /// <item>
    /// 0000-002C: TIA (Write)
    /// </item>
    /// <item>
    /// 0030-003D: TIA (Read)
    /// </item>
    /// <item>
    /// 0080-00FF: RIOT RAM
    /// </item>
    /// <item>
    /// 0280-0297: RIOT I/O, TIMER
    /// </item>
    /// <item>
    /// F000-FFFF: ROM
    /// </item>
    /// </list>
    /// </para>
    /// <para>
    /// Because of the way the chips are wired and the lack of the upper address lines in the 6507, TIA, RIOT
    /// and cart addresses are mirrored several times across the 64K address space. Here you can find the full
    /// address map including all the mirrors: http://atariage.com/forums/topic/192418-mirrored-memory/?do=findComment&comment=2439795
    /// </para>
    /// </remarks>
    public class VirtualMachine
    {
        private Rom vmRom;
        private Stack vmStack;

        /// <summary>
        /// The Program Counter (PC) of 6502 family microprocessor is a 16 bit register, which is always pointing to the next instruction
        /// to be fetched and executed (fetch cycle). Then, the address stored in the Program Counter (PC) will be updated immediately
        /// after the newly fetched instruction is executed. Moreover, the Program Counter(PC) can also be modified by any branching, interrupt
        /// or subroutine subroutine operations and it will then be modified by returning from the subroutine or interrupt, too.
        /// </summary>
        internal ushort ProgramCounter { get; set; }

        /// <summary>
        /// During arithmetic operations, when the Decimal Flag has been set (values equal to 1), it force the microprocessor to treat numbers
        /// as Binary Coded Decimal (BCD), we call it BCD Mode. On the other hand, when the Decimal Flag has been clear (values equal to 0), it
        /// force the microprocessor to treat numbers as normal binary numbers, i.e. Binary Mode.  Decimal Flag can be changed explicitly using
        /// the SED or CLD operations.  There are two arithmetic operations that affected by the Decimal Flag: ADC (Add with Carry) and SBC
        /// (Subtract with Carry).
        /// </summary>
        internal bool DecimalFlag { get; set; }

        /// <summary>
        /// The 6502 family microprocessors will NOT response if the Interrupt Flag is set to 1.  On the other hand, if the Interrupt Flag is set
        /// to 0, the 6502 family microprocessor resume a normal state that it will react to any interrupt request. Thus, the reaction to interrupt
        /// request can be DISABLED by SEI operation and ENABLED by CLI operation.  SEI and CLI operations are designed specific for setting and
        /// clearing the Interrupt Flag.
        /// </summary>
        internal bool InterruptFlag { get; set; }

        internal bool NegativeFlag { get; set; }

        /// <summary>
        /// Register X is one of the two Index Registers for a normal 6502 family microprocessor. Register X is an 8 bit register.
        /// It is normally acted as a counter or storing offsets for accessing memory. Their values can be incremented (INX) or
        /// decremented (DEX). And they are connected directly to data bus, thus, their value can be loaded (LDX) , saved in  (STX)
        /// or compared with (CPX ) the values stored in memory. The Register X is normally similar to Register Y, except the Register X
        /// can also be used to get a copy of the Stack Pointer(SP) or change its value.
        /// </summary>
        internal byte RegisterX { get; set; }

        internal byte Accumulator { get; set; }

        /// <summary>
        /// The Zero Flag is set if the value of the Register of the last operation has been changed to zero. There is no
        /// explicit operation specific for setting or clearing the Zero Flag.
        /// </summary>
        /// <remarks>
        /// An automatic compare-to-zero instruction is built into the following 6502 instructions: LDA, LDX, LDY, INC, INX, INY, DEC,
        /// DEX, DEY, INA, DEA, AND, ORA, EOR, ASL, LSR, ROL, ROR, PLA, PLX, PLY, SBC, ADC, TAX, TXA, TAY, TYA, and TSX.
        /// </remarks>
        internal bool ZeroFlag { get; set; }

        /// <summary>
        /// Zero-Page is an addressing mode that is only capable of addressing the first 256 bytes of the CPU's memory map. You can think of it
        /// as absolute addressing for the first 256 bytes. The instruction LDA $35 will put the value stored in memory location $35 into A.
        /// The advantage of zero-page are two - the instruction takes one less byte to specify, and it executes in less CPU cycles. Most programs
        /// are written to store the most frequently used variables in the first 256 memory locations so they can take advantage of zero page addressing.
        /// </summary>
        internal byte[] ZeroPage;

        internal static readonly ushort PageSize = 256;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public VirtualMachine()
        {
            vmRom = new Rom(this);
            vmStack = new Stack();
            ZeroPage = new byte[PageSize];
        }

        /// <summary>
        /// Load a ROM from file contents.
        /// </summary>
        /// <param name="path">
        /// The path of the file whose contents should be loaded into ROM.
        /// </param>
        public void LoadRom(string path)
        {
            vmRom.Load(path);
        }

        /// <summary>
        /// Run the code in the virtual machine.
        /// </summary>
        /// When powered on, the 6502 loads the "reset vector" (stored in locations $FFFC-$FFFB, which are in ROM)
        /// into the program counter (the internal register which holds the address of the next instruction to be
        /// fetched) and starts fetching instructions from there.
        /// </remarks>
        public void Run()
        {
            var keepRunning = true;
            ProgramCounter = vmRom.GetAddressOfFirstInstruction();
            while(keepRunning)
            {
                var instructionToExecute = GetInstructionAtProgramCounter();
                instructionToExecute.Execute();

                // Check to see if the program counter is still the same as the address of the instruction. If it is,
                // move the program counter past the bytes of the current instruction so that it points to the next
                // instruction. Some instructions, notably the branch instructions such as BNE, may have manually adjusted
                // the program counter as a part of their execution. If that has happened, then the new program counter
                // value will not match the ROM address, and the new value of the program counter should be used rather
                // than automatically moving to the next instruction.

                if (this.ProgramCounter == instructionToExecute.RomAddress)
                {
                    this.ProgramCounter += instructionToExecute.Bytes;
                }
            }
        }

        /// <summary>
        /// Returns the instruction at the virtual machine's program counter.
        /// </summary>
        /// <returns>
        /// The instruction at the virtual machine's program counter. I literally just said that.
        /// </returns>
        private Instruction GetInstructionAtProgramCounter()
        {
            return vmRom.GetInstructionAtProgramCounter(this.ProgramCounter);
        }

        /// <summary>
        /// Read the word at the given address.
        /// </summary>
        /// <param name="address">
        /// The address storing the word to be read.
        /// </param>
        /// <returns>
        /// The word value at the address.
        /// </returns>
        internal ushort ReadWord(ushort address)
        {
            if(vmRom.IsRomAddress(address))
            {
                return vmRom.ReadWord(address);
            }
            throw new NotSupportedException($"Reading word from address {address} is not supported.");
        }

        /// <summary>
        /// Read the byte at the given address.
        /// </summary>
        /// <param name="address">
        /// The address storing the byte to be read.
        /// </param>
        /// <returns>
        /// The byte value at the address.
        /// </returns>
        internal byte ReadByte(ushort address)
        {
            if(vmRom.IsRomAddress(address))
            {
                return vmRom.ReadByte(address);
            }
            throw new NotSupportedException($"Reading byte from address {address} is not supported.");
        }

        /// <summary>
        /// Read the byte at the program counter address.
        /// </summary>
        /// <remarks>
        /// The program counter is advanced after the read.
        /// </remarks>
        /// <returns>
        /// The byte at the program counter address.
        /// </returns>
        internal byte ReadByteAtProgramCounter()
        {
            var opcode = ReadByte(ProgramCounter);
            ProgramCounter++;
            return opcode;
        }

        /// <summary>
        /// Read the word at the program counter address.
        /// </summary>
        /// <remarks>
        /// The program counter is advanced after the read.
        /// </remarks>
        /// <returns>
        /// The word at the program counter address.
        /// </returns>
        internal ushort ReadWordAtProgramCounter()
        {
            var opcode = ReadWord(ProgramCounter);
            ProgramCounter++;
            ProgramCounter++;
            return opcode;
        }

        /// <summary>
        /// Pushes a byte value onto the stack.
        /// </summary>
        /// <param name="value">
        /// The byte value to push onto the stack.
        /// </param>
        internal void PushValueOnStack(byte value)
        {
            vmStack.Push(value);
        }

        /// <summary>
        /// Pushes an unsigned short byte value onto the stack.
        /// </summary>
        /// <param name="value">
        /// The unsigned short value to push onto the stack.
        /// </param>
        internal void PushValueOnStack(ushort value)
        {
            vmStack.Push(value);
        }
    }
}
