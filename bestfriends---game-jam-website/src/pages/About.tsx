import { motion } from 'motion/react';
import { Calendar, Users, Target, BookOpen, UserCircle2 } from 'lucide-react';

export default function About() {
  const team = [
      {name: "Nathan, Mehmed & Medha",
      role: "Visual Artists",
      details: "Crafted the pixel art and environmental assets that bring the mysterious tower to life.",
      icon: "🎨"
    },
    {
      name: "Raymond & Ekansh",
      role: "Unity Developers",
      details: "Built the core gameplay loops, physics systems, and cooperative mechanics using Unity 2026.",
      icon: "🕹️"
    },
    {
      name: "AJ",
      role: "Web Development",
      details: "Architected the digital presence and technical interface for the BestFriends project.",
      icon: "🌐"
    }
  ];

  return (
    <div className="max-w-7xl mx-auto px-6 py-20 lg:py-32">
      <div className="max-w-4xl mb-24">
        <motion.div
           initial={{ opacity: 0, y: 20 }}
           whileInView={{ opacity: 1, y: 0 }}
           viewport={{ once: true }}
        >
          <div className="inline-flex items-center gap-3 mb-8">
            <Calendar className="w-5 h-5 text-brand-sky" />
            <span className="text-slate-500 font-sans text-xs font-bold tracking-[0.3em] uppercase">Established May 2026</span>
          </div>
          <h1 className="text-6xl lg:text-8xl font-serif italic font-bold mb-10 tracking-tight text-white leading-tight">
            Behind the <span className="text-brand-sky">Creative</span> <br /> Process.
          </h1>
          <p className="text-xl text-slate-400 leading-relaxed max-w-2xl font-light">
            Built from scratch (and some learning unity along the way), with love, for the Computer Science Game Jam
          </p>
        </motion.div>
      </div>

      {/* Origin Story Section */}
      <div className="mb-40">
        <motion.div
           initial={{ opacity: 0, x: -50 }}
           whileInView={{ opacity: 1, x: 0 }}
           viewport={{ once: true }}
           className="space-y-12 lg:col-span-2"
        >
          <div className="group">
             <div className="flex items-center gap-4 mb-4">
                <Target className="text-brand-sky w-5 h-5" />
                <h3 className="text-xs uppercase tracking-[0.3em] text-white/40 font-bold">The Vision</h3>
             </div>
             <p className="text-slate-300 text-lg leading-relaxed font-sans font-light">
                Inspired by games like Fireboy and Watergirl, we wanted to create an inspired game with our own twist: a unique, changing tower.
             </p>
          </div>
          
          <div className="group">
             <div className="flex items-center gap-4 mb-4">
                <BookOpen className="text-brand-amber w-5 h-5" />
                <h3 className="text-xs uppercase tracking-[0.3em] text-white/40 font-bold">How to Play</h3>
             </div>
             <div className="grid sm:grid-cols-2 gap-6">
                <div className="space-y-2">
                   <p className="text-sm text-white font-bold tracking-tight italic font-serif">01. Coordinate</p>
                   <p className="text-xs text-slate-500 leading-relaxed">Sync movements to navigate shifting floors.</p>
                </div>
                <div className="space-y-2">
                   <p className="text-sm text-white font-bold tracking-tight italic font-serif">02. Collect</p>
                   <p className="text-xs text-slate-500 leading-relaxed">Find keys to unlock path-blocking portals.</p>
                </div>
                <div className="space-y-2">
                   <p className="text-sm text-white font-bold tracking-tight italic font-serif">03. Boost</p>
                   <p className="text-xs text-slate-500 leading-relaxed">Utilize jump pads for high-altitude reach.</p>
                </div>
                <div className="space-y-2">
                   <p className="text-sm text-white font-bold tracking-tight italic font-serif">04. Escape</p>
                   <p className="text-xs text-slate-500 leading-relaxed">Reach the end to secure your best time.</p>
                </div>
             </div>
          </div>
        </motion.div>
      </div>

      {/* Team Section */}
      <div className="space-y-16 border-t border-white/5 pt-20">
        <div className="flex items-center justify-between">
          <h2 className="text-xs uppercase tracking-[0.4em] text-white/30 font-bold">The Creative Founders</h2>
          <div className="h-[1px] flex-1 bg-white/5 mx-8" />
        </div>
        
        <div className="grid md:grid-cols-3 gap-8">
          {team.map((member, i) => (
            <motion.div
              key={member.name}
              initial={{ opacity: 0, y: 20 }}
              whileInView={{ opacity: 1, y: 0 }}
              viewport={{ once: true }}
              transition={{ delay: i * 0.1 }}
              className="p-10 rounded-2xl bg-brand-card border border-white/5 hover:border-white/20 transition-all group relative overflow-hidden"
            >
              <div className="text-4xl mb-8 grayscale group-hover:grayscale-0 transition-all transform group-hover:scale-110">{member.icon}</div>
              <h3 className="text-xl font-serif italic font-bold mb-1 text-white leading-tight">{member.name}</h3>
              <p className="text-[10px] text-brand-sky font-bold uppercase tracking-[0.2em] mb-6">{member.role}</p>
              <p className="text-xs text-slate-500 leading-relaxed font-light">{member.details}</p>
            </motion.div>
          ))}
        </div>
      </div>
    </div>
  );
}
