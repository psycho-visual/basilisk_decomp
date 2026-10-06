typedef unsigned char   undefined;

typedef unsigned char    byte;
typedef unsigned int    dword;
typedef unsigned char    undefined1;
typedef unsigned short    undefined2;
typedef unsigned int    undefined4;
typedef unsigned short    ushort;
typedef struct razer_report_t razer_report_t, *Prazer_report_t;

struct razer_report_t {
    byte status; /* 0x00 new, 0x01 busy, 0x02 ok, 0x03 fail, 0x04 timeout, 0x05 not supported */
    byte transaction_id;
    byte remaining_packets[2]; /* big endian */
    byte protocol_type;
    byte data_size;
    byte command_class;
    byte command_id; /* bit7 set = get/read */
    byte args[80];
    byte crc; /* XOR of bytes 2..87 */
    byte reserved;
};

