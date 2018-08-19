﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperTileMapper
{
    public partial class SuperTileMapper : Form
    {
        bool changes = false;
        VRAMEditor vram;
        CGRAMEditor cgram;
        OAMEditor oam;
        PPURegEditor ppu;

        public SuperTileMapper()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            vram = new VRAMEditor();
            vram.Close();
            cgram = new CGRAMEditor();
            cgram.Close();
            oam = new OAMEditor();
            oam.Close();
            ppu = new PPURegEditor();
            ppu.Close();
            Data.PPURegs[0x00] = 0x0F;
            Data.PPURegs[0x1B] = 0x100;
            Data.PPURegs[0x1E] = 0x100;
            Data.PPURegs[0x30] = 0x30;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void vRAMEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (vram.IsDisposed)
            {
                vram = new VRAMEditor();
            }
            vram.Show();
        }

        private void cGRAMEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cgram.IsDisposed)
            {
                cgram = new CGRAMEditor();
            }
            cgram.Show();
        }

        private void oAMEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (oam.IsDisposed)
            {
                oam = new OAMEditor();
            }
            oam.Show();
        }

        private void pPURegistersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ppu.IsDisposed)
            {
                ppu = new PPURegEditor();
            }
            ppu.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (changes)
            {
                // save?
            } else
            {
                Application.Exit();
            }
        }

        private void SuperTileMapper_Resize(object sender, EventArgs e)
        {
            bool vis = (WindowState != FormWindowState.Minimized);
            if (!vram.IsDisposed && vis) vram.Show();
            if (!vram.IsDisposed && !vis) vram.Hide();
            if (!cgram.IsDisposed && vis) cgram.Show();
            if (!cgram.IsDisposed && !vis) cgram.Hide();
            if (!oam.IsDisposed && vis) oam.Show();
            if (!oam.IsDisposed && !vis) oam.Hide();
            if (!ppu.IsDisposed && vis) ppu.Show();
            if (!ppu.IsDisposed && !vis) ppu.Hide();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }
    }
}
