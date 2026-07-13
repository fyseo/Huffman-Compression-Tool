#include <iostream>
#include <string>
#include <fstream>
using namespace std;

//Struct node was taken from lecture code with modification include req data
struct Node
{
	char data;
	int freq;
	Node* left, * right;
	Node* next, * prev;

	Node(char d = NULL, int f = 0)
	{
		freq = f;
		data = d;
		next = prev = left = right = NULL;
	}
};

//Class linkedlist was taken from lecture code with modification to work with the nodes
class LinkedList
{
	Node* header;

public:
	//Methods are inspired from lecture notes with some necessery edits
	LinkedList()
	{
		header = NULL;
	}

	~LinkedList()
	{
		Node* it = header;
		while (it != NULL)
		{
			Node* tmp = it->next;
			delete (it);
			it = tmp;
		}
	}

	bool InsertSorted(Node* node)
	{

		if (!node)
		{
			return false;
		}

		if (header == NULL)
		{
			header = node;
			return true;
		}

		if (node->freq < header->freq)
		{
			node->next = header;
			header->prev = node;
			header = node;
			return true;

		}

		Node* tmp = header;

		while (tmp->next != NULL && tmp->next->freq <= node->freq)
		{
			tmp = tmp->next;
		}

		node->next = tmp->next;
		node->prev = tmp;


		if (tmp->next != NULL)
		{
			tmp->next->prev = node;
		}

		tmp->next = node;

		return true;
	}

	Node* RemoveFirst()
	{
		if (!header)
			return NULL;


		Node* tmp = header;


		if (header->next != NULL)
		{
			header = header->next;
			header->prev = NULL;
		}
		else
		{
			header = NULL;
		}
		tmp->next = NULL;
		tmp->prev = NULL;

		return tmp;
	}

	int GetSize()
	{

		int count = 0;
		Node* current = header;
		while (current != NULL)
		{
			count++;
			current = current->next;
		}
		return count;
	}

};

//Build huffmantree recursion is inspired from online lecture and tree code
Node* BuildHuffmanTree(LinkedList* list)
{
	char data1, data2;
	int freq1, freq2;

	while (true)
	{
		Node* r1 = list->RemoveFirst();
		Node* r2 = list->RemoveFirst();

		if (r1 == NULL && r2 == NULL)
		{
			return NULL;
		}
		if (r2 == NULL)
		{
			return r1;
		}

		
		Node* link = new Node(NULL, r1->freq + r2->freq);
		link->left = r1;
		link->right = r2;

		list->InsertSorted(link);
	}

}

//Function readfile takes the name of the input file and an empty freq table to 
//read the file and fill the freq table with the buffer size
void ReadFile(long buffer_size, char* filename, int freqtable[256])
{
	FILE* FR;
	char* buffer;
	FR = fopen(filename, "rb");

	if (FR == NULL)
	{
		printf("Error reading file! \n");
		return;
	}

	buffer = new char[buffer_size];
	if (!buffer) {
		printf("Error allocating memory! \n");
		fclose(FR);
		return;
	}

	size_t bytes_read = 0;
	size_t total_bytes_read = 0;

	while ((bytes_read = fread(buffer, 1, buffer_size, FR)) > 0) {
		total_bytes_read += bytes_read;


		for (int i = 0; i < bytes_read; i++) {
			unsigned char byte = (unsigned char)(buffer[i]);
			freqtable[byte]++;
		}
	}

	if (ferror(FR)) {
		printf("Error reading file! \n");
		delete[] buffer;
		return;
	}



	fclose(FR);
	return;
}

//TableGen function inspired from:https://www.geeksforgeeks.org/huffman-coding-greedy-algo-3/
void TableGen(string table[256], Node* recNode, string c)
{
	if (recNode == NULL)
		return;
	if (recNode->left == NULL && recNode->right == NULL)
	{

		table[(unsigned char)recNode->data] = c;
		return;
	}

	TableGen(table, recNode->left, c + '0');
	TableGen(table, recNode->right, c + '1');

}

//Build sorted list function builds a linked list sorted from freq table build earlier
LinkedList BuildSortedList(int freq[256])
{
	LinkedList base;

	for (int i = 0; i < 256; i++) // inserts from smallest to biggest
	{
		if (freq[i] > 0) //disregards 0 frequenceys
		{
			Node* node = new Node((char)i,freq[i]);

			base.InsertSorted(node);
		}

	}

	return base;

}

void Compression(long buffer_size, char* inputFile, char* outputFile)
{
	//Creating frequency table and fill it from file 
	int freqtable[256] = { 0 };
	ReadFile(buffer_size, inputFile, freqtable);

	//Build the sorted queue from frequency table
	LinkedList queue = BuildSortedList(freqtable);
	int sizeque = queue.GetSize();

	//Build the huffman tree and generete the codes table from the tree
	Node* Root = BuildHuffmanTree(&queue);
	string codeTable[256] = {};
	TableGen(codeTable, Root, "");

	//Open input and output files
	ifstream input(inputFile, ios::binary);
	if (!input)
	{
		printf("Error reading from file! \n");
		return;
	}

	ofstream output(outputFile, ios::binary);
	if (!output)
	{
		printf("Error writing to file! \n");
		return;
	}

	//Write number of codes in table with freq more than 0 to file
	output.write((char*)(&sizeque), sizeof(int));

	//Writing the header itself
	for (int i = 0; i < 256; i++)
	{

		if (freqtable[i] > 0)
		{
			
			char letter = (char)i;
			char codelength = codeTable[i].length();

			//Writing the char and length of code for each code
			output.write((char*)(&letter), sizeof(char));
			output.write((char*)(&codelength), sizeof(char));


			//Bit packing the each code and writing it to the file
			//Bit packing and bitwise operations refrences: many articles on https://www.geeksforgeeks.org
			char byte = 0;
			int counter = 0;

			for (auto bit : codeTable[i])
			{
				byte <<= 1;
				if (bit == '1') byte |= 1;
				counter++;

				if (counter == 8) {
					output.write((char*)(&byte), sizeof(char));
					byte = 0;
					counter = 0;
				}

			}
			if (counter > 0)
			{
				byte <<= (8 - counter);
				output.write((char*)(&byte), sizeof(char));
			}

		}
	}


	//Writing the actual compressed data using set buffer size
	char* buffer = new char[buffer_size];
	size_t bytes_read = 0;
	char byte = 0;
	int counter = 0;
	string bitstream = "";
	while (input.read(buffer, buffer_size) || input.gcount() > 0) {
		bytes_read = input.gcount();

		//Add the compressed data from codes to a string before writing it to the file
		for (int i = 0; i < bytes_read; i++)
		{
			unsigned char temp = (unsigned char)(buffer[i]);
			string letter = codeTable[temp];
			bitstream += letter;

		}

		string temp = "";//
		//Writing codes bit by bit
		for (auto bit : bitstream)
		{
			
			byte <<= 1;
			if (bit == '1') byte |= 1;
			counter++;

			if (counter == 8) {
				/*output.write((char*)(&byte), sizeof(char));*/
				temp += byte;
				byte = 0;
				counter = 0;
			}

		}
		output.write(temp.c_str(), temp.size());
		bitstream = "";
	}

	//Write the last unfinished byte if exists 
	unsigned char leftoverbits = counter;
	if (leftoverbits > 0)
	{
		byte <<= (8 - leftoverbits);
		output.write((char*)(&byte), 1);
	}
	else
	{
		byte = 0;
		output.write((char*)(&byte), 1);
	}

	//Then writing the number of valid bits in the last byte
	output.write((char*)(&leftoverbits), 1);

	//Closing input and output files and deleting buffer
	input.close();
	output.close();
	delete[] buffer;

}

void Decompression(long buffer_size, char* inputFile, char* outputFile)
{

	//Open input and output files
	ifstream input(inputFile, ios::binary);
	if (!input)
	{
		printf("Error reading from file! \n");
		return;
	}

	ofstream output(outputFile, ios::binary);
	if (!output)
	{
		printf("Error writing to file! \n");
		return;
	}

	//Read number of codes from first byte
	int numcodes = 0;
	input.read((char*)&numcodes, sizeof(int));
	
	if (input.fail())
	{
		printf("Error reading number of codes! \n");
		return;
	}


	//Create refrence tree root node
	Node* Root = new Node();

	//Header reading
	for (int i = 0; i < numcodes; i++) //looping table items
	{
		char ch;
		char sizecodechar;
		string code;

		//Reading char byte and size of code byte for each code
		input.read(&ch, sizeof(char));
		input.read(&sizecodechar, sizeof(char));
		int sizecode = (char)sizecodechar;

		//reading each code byte by byte intp a string
		while (code.length() < sizecode) 
		{

			char byte;
			input.read(&byte, sizeof(char));

			for (int i = 7; i >= 0 && code.length()< sizecode; --i) 
			{
				code += ((byte >> i) & 1) ? '1' : '0';
			}

		}

		//Building tree using code string
		Node* current = Root;
		
		for (auto bit : code)
		{
			
			if (bit == '0') {
				if (current->left == NULL) {
					current->left = new Node();
				}
				current = current->left;
			}
			else {
				if (current->right == NULL) {
					current->right = new Node();
				}
				current = current->right;
			}

		}

		current->data = ch;
	}

	//Save the start of the actual data
	streampos accdatastart = input.tellg();

	//Set the input to read the last 2 bytes
	input.seekg(-2, ios::end);
	char lastbyte;
	char numvalidbits;
	input.read(&lastbyte, 1);
	input.read(&numvalidbits, 1);

	//Save the end of data without the last 2 bytes
	streampos dataend = input.tellg();

	//Start reading from the actual start
	long fcsize = (long)(dataend - accdatastart - 2);
	long bytesend = fcsize * 8 + (char)numvalidbits;

	input.seekg(accdatastart);


	char* buffer = new char[buffer_size];
	string leftovers = "";
	size_t bitsread = 0;

	while (input.read(buffer, buffer_size) || input.gcount() > 0)
	{
		//Reading byte by byte and adding to string 
		string tempin = leftovers;

		for (int i = 0; i < input.gcount(); i++) 
		{

			unsigned char byte = (unsigned char)(buffer[i]); 

			for (int j = 7; j >= 0&&bitsread<bytesend; j--)
			{
				bitsread++;
				tempin += ((byte >> j) & 1) ? '1' : '0';
			}
		}

		//Traversing tree to get code for for the char
		string tempout = "";
		Node* ch = Root;

		for (size_t i=0; i < tempin.size(); i++)
		{
			char bit = tempin[i];
			if (bit == '0')
			{
				ch = ch->left;
				leftovers += '0';
			}
			if (bit == '1')
			{
				ch = ch->right;
				leftovers += '1';
			}
			if (!ch)
			{
				printf("error retreaving bit form tree");
			}
			if (ch && !ch->left && !ch->right)
			{
				tempout += ch->data;
				ch = Root;
				leftovers = "";
			}


		}

		//Writing the decompressed data to the file
		output.write(tempout.c_str(), tempout.size());
	}

	//Closing input and output files and deleting buffer
	delete[]buffer;
	input.close();
	output.close();
}

int main(int argc, char* argv[])
{
	//CLI from lecture notes
	long buffersize = 1024;
	string input, output, suffix = ".ece2103";
	bool cord = -1; //c is 0 ,d is 1 , -1 default

	if (argc == 1)
	{
		printf("Argument error. Read the manual\n");
		return -1;
	}

	for (int i = 0; i < argc; i++)
	{
		if (strcmp(argv[i], "-b") == 0)
		{
			if (i + 1 < argc) {
				try {
					buffersize = stol(argv[i + 1]);

					if (buffersize > 0)
					{
						printf("\nbuffer size = %d", buffersize);
					}
					else printf("\ninvalid buffer\n");
				}
				catch (...)
				{
					printf("\ninvalid buffer!\n");
				}
			}
			else printf("\ninvalid buffer\n");

		}
		else if (strcmp(argv[i], "-c") == 0)
		{
			if (i + 2 < argc) {
				try {
					cord = 0;
					input = argv[i + 1];
					output = argv[i + 2];
					output += suffix;
					
				}
				catch (...)
				{
					printf("\nread the manual!\n");
				}
			}
			else printf("\nread the manual!\n");

		}
		else if (strcmp(argv[i], "-d") == 0)
		{
			if (i + 2 < argc) {
				try {
					cord = 1;
					input = argv[i + 1];
					output = argv[i + 2];
					
					if (output.size() >= suffix.size() && output.compare(output.size() - suffix.size(), suffix.size(), suffix) == 0) {
						output.erase(output.size() - suffix.size());
					}
				}
				catch (...)
				{
					printf("\nread the manual!\n");
				}
				{
				}
			}
			else printf("\nread the manual!\n");


		}

	}

	switch (cord)
	{
	case(0):
		try
		{
			Compression(buffersize, (char*)input.c_str(), (char*)output.c_str());
			printf("\nCompression Successful!");
		}
		catch (...)
		{
			printf("Error Compressing");
		}
		break;

	case(1):
		try
		{
			Decompression(buffersize, (char*)input.c_str(), (char*)output.c_str());
			printf("\nDeCompression Successful!");
		}
		catch (...)
		{
			printf("Error DeCompressing");
		}
		break;

	case(-1):
		printf("Invalid Value\n");
		break;

	default:
		break;
	}
}
