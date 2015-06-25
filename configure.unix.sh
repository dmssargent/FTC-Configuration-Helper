#/bin/sh

OS=$(lsb_release -si)

echo "Doing a trial run \(I actually do nothing\)"
echo "Testing OS info..."

case $OS in
	Debian)
		echo "...found Debian"
		apt-get moo
		echo "...and that's what they mean be having \"Super Cow Powers\""
	;;
	Debian)
		echo "...found Ubuntu"
		apt-get moo
		echo "...and that's what they mean be having \"Super Cow Powers\""
	;;
	*)
		echo "Unknown Distro, as of now"
	;;
esac