import { motion } from 'motion/react';
import { Link } from 'react-router-dom';
import { ArrowRight, Play } from 'lucide-react';

export default function Home() {
  return (
    <div className="relative overflow-hidden bg-brand-bg">
      {/* Background Polish */}
      <div className="absolute inset-0 pointer-events-none">
        <div className="absolute top-[-10%] left-[-10%] w-[50%] h-[50%] bg-brand-sky/10 blur-[150px] rounded-full" />
        <div className="absolute bottom-[-10%] right-[-10%] w-[50%] h-[50%] bg-brand-amber/10 blur-[150px] rounded-full" />
      </div>

      <div className="max-w-7xl mx-auto px-6 py-20 lg:py-32 relative">
        <div className="flex flex-col items-center text-center max-w-4xl mx-auto">
          <motion.div
            initial={{ opacity: 0, y: 20 }}
            animate={{ opacity: 1, y: 0 }}
            transition={{ duration: 0.8, ease: "easeOut" }}
            className="flex flex-col items-center"
          >
            <div className="inline-block px-3 py-1 border border-brand-sky/30 text-brand-sky text-[10px] uppercase tracking-[0.2em] mb-8 rounded-full bg-brand-sky/5 shadow-sm font-sans font-medium">
              Inaugural CompSci Game Jam
            </div>
            <h1 className="text-7xl lg:text-9xl font-serif italic font-bold tracking-tight text-white leading-[0.85] mb-8">
              Escape the <br />
              <span className="text-brand-sky">Mysterious</span> <br />
              Tower
            </h1>
            <p className="text-xl text-slate-400 max-w-2xl mb-12 leading-relaxed font-sans font-extralight tracking-wide">
              A cooperative puzzle platformer where two friends must work together and use their abilities to escape a dangerous tower
            </p>
            <div className="flex flex-wrap gap-6 items-center justify-center">
              <Link
                to="/game"
                className="px-10 py-5 bg-white text-black text-xs font-bold uppercase tracking-widest hover:bg-brand-sky hover:text-white transition-all transform hover:-translate-y-1 shadow-xl"
              >
                Play Web Build
              </Link>
              <Link
                to="/about"
                className="text-xs uppercase tracking-[0.2em] font-bold text-slate-400 hover:text-white transition-colors border-b border-transparent hover:border-brand-sky pb-1"
              >
                Learn More →
              </Link>
            </div>
          </motion.div>
        </div>
      </div>
      
      {/* Featured Statistics Section */}
      <div className="border-t border-white/5 bg-brand-card/30">
        <div className="max-w-7xl mx-auto px-6 py-16">
          <div className="grid grid-cols-2 md:grid-cols-4 gap-12 text-center items-center">
            <div>
              <p className="text-4xl font-serif italic font-bold text-white mb-2 tracking-tight">2</p>
              <p className="text-[10px] uppercase tracking-[0.3em] text-slate-500 font-bold">Characters</p>
            </div>
            <div className="border-l border-white/5 h-12 hidden md:block" />
            <div className="md:-ml-24">
              <p className="text-4xl font-serif italic font-bold text-white mb-2 tracking-tight">many</p>
              <p className="text-[10px] uppercase tracking-[0.3em] text-slate-500 font-bold">Tower Floors</p>
            </div>
            <div className="border-l border-white/5 h-12 hidden md:block" />
            <div className="md:-ml-24">
              <p className="text-4xl font-serif italic font-bold text-white mb-2 tracking-tight">May</p>
              <p className="text-[10px] uppercase tracking-[0.3em] text-slate-500 font-bold">Game Jam Date</p>
            </div>
            <div className="border-l border-white/5 h-12 hidden md:block" />
            <div className="md:-ml-24">
              <p className="text-4xl font-serif italic font-bold text-brand-sky mb-2 tracking-tight">#1</p>
              <p className="text-[10px] uppercase tracking-[0.3em] text-slate-500 font-bold">Platformer</p>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
