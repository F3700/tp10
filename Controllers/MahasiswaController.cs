using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace tpmodul10_103022300003.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MahasiswaController : ControllerBase
    {
        // Data mahasiswa (contoh menggunakan list statis)
        private static readonly List<Mahasiswa> Mahasiswas = new List<Mahasiswa>
        {
            new Mahasiswa("Albert Febrian", "103022300003"),
            new Mahasiswa("Hizkia Nicander", "103022300127"),
            new Mahasiswa("Hafizh Al Kautsar", "103022300069"),
            new Mahasiswa("Bintang Anugrah", "103022300058"),
            new Mahasiswa("Syarif", "103022300094")
            // Tambahkan mahasiswa lainnya sesuai kebutuhan
        };

        // GET: api/mahasiswa
        [HttpGet]
        public IActionResult GetMahasiswa()
        {
            return Ok(Mahasiswas); // Mengembalikan semua data mahasiswa
        }

        // GET: api/mahasiswa/{id}
        [HttpGet("{id}")]
        public IActionResult GetMahasiswaById(int id)
        {
            if (id < 0 || id >= Mahasiswas.Count)
            {
                return NotFound(); // Mengembalikan "Not Found" jika ID tidak valid
            }

            return Ok(Mahasiswas[id]); // Mengembalikan data mahasiswa berdasarkan ID
        }

        // POST: api/mahasiswa
        [HttpPost]
        public IActionResult AddMahasiswa([FromBody] Mahasiswa mahasiswa)
        {
            Mahasiswas.Add(mahasiswa); // Menambahkan mahasiswa baru ke dalam list
            return CreatedAtAction(nameof(GetMahasiswaById), new { id = Mahasiswas.Count - 1 }, mahasiswa);
        }

        /*
        // PUT: api/mahasiswa/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateMahasiswa(int id, [FromBody] Mahasiswa mahasiswa)
        {
            if (id < 0 || id >= Mahasiswas.Count)
            {
                return NotFound(); // Jika ID tidak ditemukan
            }

            Mahasiswas[id] = mahasiswa; // Memperbarui data mahasiswa berdasarkan ID
            return NoContent(); // Mengembalikan status sukses tanpa body
        }
        */

        // DELETE: api/mahasiswa/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteMahasiswa(int id)
        {
            if (id < 0 || id >= Mahasiswas.Count)
            {
                return NotFound(); // Jika ID tidak ditemukan
            }

            Mahasiswas.RemoveAt(id); // Menghapus mahasiswa berdasarkan ID
            return NoContent(); // Mengembalikan status sukses tanpa body
        }
    }
}
